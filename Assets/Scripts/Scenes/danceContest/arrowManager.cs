using UnityEngine;

public class arrowManager : MonoBehaviour
{
    public gameManager myGameManager;
    public char arrow;

    private arrow lastGameObject;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (arrow)
        {
            case 'a':
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if(gameObject.tag == "waitingToPress" && lastGameObject != null)
                    {
                        StartCoroutine(lastGameObject.DestroyArrow());
                        lastGameObject = null;
                        myGameManager.addScore();
                    }
                }
                break;
            case 'd':
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (gameObject.tag == "waitingToPress" && lastGameObject != null)
                    {
                        StartCoroutine(lastGameObject.DestroyArrow());
                        lastGameObject = null;
                        myGameManager.addScore();
                    }
                }
                break;
            case 'w':
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (gameObject.tag == "waitingToPress" && lastGameObject != null)
                    {
                        StartCoroutine(lastGameObject.DestroyArrow());
                        lastGameObject = null;
                        myGameManager.addScore();
                    }
                }
                break;
            case 's':
                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (gameObject.tag == "waitingToPress" && lastGameObject != null)
                    {
                        StartCoroutine(lastGameObject.DestroyArrow());
                        lastGameObject = null;
                        myGameManager.addScore();
                    }
                }
                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.tag = "waitingToPress";
        lastGameObject = collision.gameObject.GetComponent<arrow>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.tag = "";
    }
}
