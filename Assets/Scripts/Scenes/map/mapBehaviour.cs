using UnityEngine;
using UnityEngine.SceneManagement;

public class mapBehaviour : MonoBehaviour
{
    public void mineTp()
    {
        SceneManager.LoadScene("mine");

    }
    public void townTp()
    {
        SceneManager.LoadScene("town");
    }

    public void iglooTp()
    {
        SceneManager.LoadScene("igloo");
    }
}
