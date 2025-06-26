using UnityEngine;

public class FixedRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public bool reverseRotation = false; // Marcar si rota al revés

    void Update()
    {
        float direction = reverseRotation ? -1f : 1f;
        transform.Rotate(Vector3.up, direction * rotationSpeed * Time.deltaTime);
    }
}
