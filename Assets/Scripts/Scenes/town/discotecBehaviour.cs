using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class discotecBehaviour : MonoBehaviour
{
    public float delayBeforeScene = 0.75f;


    void OnMouseDown()
    {
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {

        yield return new WaitForSeconds(delayBeforeScene);
        SceneManager.LoadScene("dance");
    }
}
