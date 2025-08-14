using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class enterGame : MonoBehaviour
{
    public float delayBeforeScene = 1.0f;


    void OnMouseDown()
    {
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {

        yield return new WaitForSeconds(delayBeforeScene);
        SceneManager.LoadScene("DanceGame");
    }
}
