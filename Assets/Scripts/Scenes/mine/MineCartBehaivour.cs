using UnityEngine;
using UnityEngine.SceneManagement;

public class MineCartBehaivour : MonoBehaviour
{
    public GameObject MineGame;
    public string nameScene = "CartSurfer";

    void Start()
    {
        if (MineGame != null)
        {
            MineGame.SetActive(false);
        }
    }

    void OnMouseDown() 
    {
        if (MineGame != null)
        {
            UnityEngine.Debug.Log("se muestra canva");
            MineGame.SetActive(true); // Mostrar Canvas
        }
    }
}
