using UnityEngine;

public class lights : MonoBehaviour
{
    public float rotationSpeed = 25f; // Degrees per second

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime, Space.Self);
    }
}
