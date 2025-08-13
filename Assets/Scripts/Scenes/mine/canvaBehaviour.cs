using UnityEngine;
using UnityEngine.SceneManagement;

public class canvaBehaviour : MonoBehaviour
{
    public string nombreEscenaDestino = "CartSurfer";

    public void Jugar()
    {
        SceneManager.LoadScene(nombreEscenaDestino);
    }

    public void Cancelar()
    {
        gameObject.SetActive(false);
    }
}
