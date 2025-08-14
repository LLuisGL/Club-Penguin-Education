using UnityEngine;

public class scaleObject : MonoBehaviour
{
    private Vector3 escalaOriginal;
    public float factorEscala = 1.2f;

    void Start()
    {
        escalaOriginal = transform.localScale;
    }

    void OnMouseEnter()
    {
        transform.localScale = escalaOriginal * factorEscala;
    }

    void OnMouseExit()
    {
        transform.localScale = escalaOriginal;
    }
}
