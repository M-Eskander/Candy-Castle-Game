using System;
using UnityEngine;

public class DestroyPassingObjects : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") && !other.CompareTag("BadCandy"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.LoseLife();
        }

        if (other.CompareTag("BadCandy"))
            Destroy(other.gameObject);
    }
}
