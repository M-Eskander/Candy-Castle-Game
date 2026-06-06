using UnityEngine;

public class CandySpinner : MonoBehaviour
{
    public float Speed = 100f;

    void Update()
    {
        transform.Rotate(0f, 0f, -Speed * Time.deltaTime);
    }
}
