using System;
using UnityEngine;

public class Basket : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BadCandy"))
        {
            GameManager.Instance.LoseLife();
            GameManager.Instance.AddScore(-10);
        }
        else
        {
            GameManager.Instance.AddScore(10);
        }
        Destroy(other.gameObject);
        
    }

    private float _minX, _maxX;
    public float sensetivity = 10f;
    private void Start()
    {
        _minX = GameManager.Instance.minX;
        _maxX = GameManager.Instance.maxX;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float t = (touch.deltaPosition.x / Screen.width) * sensetivity;
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(transform.position.x + t, _minX, _maxX);
            transform.position = pos;
        }
        else if (Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            float t = (Input.GetAxis("Mouse X") / Screen.width) * 50f;
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x + t, _minX, _maxX);
            transform.position = pos;
        }
    }
}
