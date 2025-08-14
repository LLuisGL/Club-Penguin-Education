using UnityEngine;

public class arrowManager : MonoBehaviour
{
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
                if (Input.GetKey(KeyCode.A))
                {
                    if(gameObject.tag == "waitingToPress" && lastGameObject != null)
                    {
                        StartCoroutine(lastGameObject.DestroyArrow());
                        lastGameObject = null;
                    }
                }
                break;
            case 'd':
                if (Input.GetKey(KeyCode.D))
                {
                    if (gameObject.tag == "waitingToPress" && lastGameObject != null)
                    {
                        StartCoroutine(lastGameObject.DestroyArrow());
                        lastGameObject = null;
                    }
                }
                break;
            case 'w':
                if (Input.GetKey(KeyCode.W))
                {
                    if (gameObject.tag == "waitingToPress" && lastGameObject != null)
                    {
                        StartCoroutine(lastGameObject.DestroyArrow());
                        lastGameObject = null;
                    }
                }
                break;
            case 's':
                if (Input.GetKey(KeyCode.S))
                {
                    if (gameObject.tag == "waitingToPress" && lastGameObject != null)
                    {
                        StartCoroutine(lastGameObject.DestroyArrow());
                        lastGameObject = null;
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
