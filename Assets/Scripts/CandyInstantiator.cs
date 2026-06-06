using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CandyInstantiator : MonoBehaviour
{
    public GameObject[] candy;
    
    private float _maxY;
    private float _minX;
    private float _maxX;
    private float _timer;
    
    public float spawnRate = 1.5f;
    private void Start()
    {
        _maxY = GameManager.Instance.maxY;
        _minX = GameManager.Instance.minX;
        _maxX = GameManager.Instance.maxX;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= spawnRate)
        {
            SpawnCandy();
            _timer = 0;
        }

        if (GameManager.Instance.Score >= 50)
        {
            if(spawnRate < 0.17)
                return;
            spawnRate -= Time.deltaTime * 0.025f;
        }
    }

    public void SpawnCandy()
    {
        float randomOne = Random.Range(_minX, _maxX);
        float randomTwo = Random.Range(_minX, _maxX);
        Vector3 randomPosTwo = new Vector3(randomTwo, _maxY, 0);
        Vector3 randomPos = new Vector3(randomOne, _maxY + 1, 0);
        Instantiate(candy[Random.Range(0, candy.Length)], randomPos, Quaternion.identity);
        if(GameManager.Instance.Score > 500)
            Instantiate(candy[Random.Range(0, candy.Length)], randomPosTwo, Quaternion.identity);
    }
}
