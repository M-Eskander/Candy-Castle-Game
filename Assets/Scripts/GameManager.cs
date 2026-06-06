using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public float Score { get; private set; }
    public float Lives { get; private set; }
    public float maxY;
    public float minX;
    public float maxX;
    
    public GameObject Player;
    public GameObject candyInstantiator;
    public GameObject Prize1;
    public GameObject Prize2;
    public GameObject Prize3;
    public GameObject Prize4;
    public GameObject Prize5;
    public GameObject Prize6;
    public GameObject ScoreandLives;
    public GameObject time;
    public GameObject date;
    public TextMeshProUGUI UiScore;
    public TextMeshProUGUI UiScoreShadow;
    public TextMeshProUGUI UiLives;
    public TextMeshProUGUI UiLivesShadow;
    public TextMeshProUGUI DateText;
    public TextMeshProUGUI TimeText;

    private int _uiScore;
    private int _uiLives;
    private float _maxLives;
    private float _scoreTickInterval = 0.05f;
    private float _scoreTickTimer;
    public bool gameOver = false;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    void Start()
    {
        Lives = 10;
        Score = 0;
        _maxLives = Lives;
    }

    private void Update()
    {
        DateTime now = DateTime.Now;
        DateText.text = now.ToString("dd/MM/yyyy");
        TimeText.text = now.ToString("hh:mm:ss tt");
        HandleGameOver();
    }
    
    void FixedUpdate()
    {
        UpdateUiScore();
    }
    
    public void AddScore(float amount)
    {
        Score += amount;
        if (Score > 100)
        {
            float newY = Mathf.Max(Physics2D.gravity.y - 0.05f, -30f); // set a floor
            Physics2D.gravity = new Vector2(0, newY);
        }
    }

    public void LoseLife()
    {
        Lives--;
    }
    
    private void UpdateUiScore()
    {
        _scoreTickTimer -= Time.fixedDeltaTime;
        if (_scoreTickTimer <= 0f)
        {
            SetUiScore();
            _scoreTickTimer = _scoreTickInterval;
        }
    }
    
    void SetUiScore()
    {
        if (_uiScore < Score)
            _uiScore ++;
        else if (_uiScore > Score)
            _uiScore--;
        UiScore.text = _uiScore.ToString();
        UiScoreShadow.text = _uiScore.ToString();

        _uiLives = Mathf.CeilToInt((Lives / _maxLives) * 3);
        if(gameOver) _uiLives = 0;
        UiLives.text = _uiLives.ToString();
        UiLivesShadow.text = _uiLives.ToString();
    }
    
    private void HandleGameOver()
    {
        if (Lives <= 0 && !gameOver)
        {
            Destroy(Player.gameObject.GetComponent<Basket>());
            Destroy(candyInstantiator);
            gameOver = true;
        }

        if (gameOver)
        {
            ShowPrize(Mathf.CeilToInt(Score / 180));
        }
    }

    void ShowPrize(int prize)
    {
        if (!gameOver)
        {
            Prize1.SetActive(false);
            Prize2.SetActive(false);
            Prize3.SetActive(false);
            Prize4.SetActive(false);
            Prize5.SetActive(false);
            Prize6.SetActive(false);
            time.SetActive(false);
            date.SetActive(false);
            ScoreandLives.GetComponent<RectTransform>().anchoredPosition = new Vector3(150, 835, 0);
        }
        if (prize <= 1)
        {
            ScoreandLives.GetComponent<RectTransform>().anchoredPosition = new Vector3(162, 244, 0);
            Prize1.SetActive(true);   
        }
        else if (prize == 2)
        {
            ScoreandLives.GetComponent<RectTransform>().anchoredPosition = new Vector3(162, 477, 0);
            time.SetActive(true);
            date.SetActive(true);
            Prize2.SetActive(true);
        }
        else if (prize == 3)
        {
            ScoreandLives.GetComponent<RectTransform>().anchoredPosition = new Vector3(162, 477, 0);
            time.SetActive(true);
            date.SetActive(true);
            Prize3.SetActive(true);
        }
        else if (prize == 4)
        {            
            ScoreandLives.GetComponent<RectTransform>().anchoredPosition = new Vector3(162, 477, 0);
            time.SetActive(true);
            date.SetActive(true);
            Prize4.SetActive(true);
        }
            
        else if (prize == 5)
        {
            ScoreandLives.GetComponent<RectTransform>().anchoredPosition = new Vector3(162, 477, 0);
            time.SetActive(true);
            date.SetActive(true);
            Prize5.SetActive(true);
        }
        else if (prize == 6)
        {
            ScoreandLives.GetComponent<RectTransform>().anchoredPosition  = new Vector3(162, 477, 0);
            time.SetActive(true);
            date.SetActive(true);
            Prize6.SetActive(true);
        }
    }
    
    public void RestartGame()
    {
        if (gameOver)
        {
            Physics2D.gravity = new Vector2(0, -9.81f); // reset to default!
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}