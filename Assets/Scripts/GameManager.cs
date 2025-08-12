using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UnityEngine.UI.Text textScore;
    public int score;
    public PlayerMovement player;
    public BackgroundAnimator background;
    private Coroutine isDeathCoRu;
    private bool play_flag;


    private bool isAlive;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // No destruir al cambiar escena
        }
        else
        {
            Destroy(gameObject);  // Evitar duplicados
        }
    }

    public void AddScore()
    {
        score++;
        textScore.text = score.ToString();
    }

    void Start()
    {
        isDeathCoRu = StartCoroutine(IsDeath());
        isAlive = true;
    }

    void Update()
    {
        if(!isAlive)
        {
            StopCoroutine(isDeathCoRu);
        }
    }

    IEnumerator IsDeath()
    {
        while (true)
        {
            if (player.tag != background.tag && isAlive && background.tag != "straight")
            {
                StartCoroutine(player.DeathAnimation());
                yield return new WaitForSeconds(2.5f);
                SceneManager.LoadScene("mine");
                isAlive = false;
            }
            yield return new WaitForSeconds(0.005f);
        }
    }

    public bool havePlay()
    {
        return this.play_flag;
    }

    public void switchPlay()
    {
        this.play_flag = !play_flag;
    }
}