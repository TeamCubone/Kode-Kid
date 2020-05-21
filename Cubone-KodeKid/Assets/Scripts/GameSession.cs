using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int PlayerLives = 3;
    [SerializeField] int Score = 0;
    [SerializeField] Text LivesText;
    [SerializeField] Text ScoreText;
    [SerializeField] float LevelLoadDealy = 2f;
    [SerializeField] AudioClip DeathSFX;
    [SerializeField] public Text RoundTicker;

    public int RoundCounter;
    private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LivesText.text = PlayerLives.ToString();
        ScoreText.text = Score.ToString();
        StartCoroutine(FadeOutRound());
    }

    void Update()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 2)
        {
            RoundTicker.text = $"Tutorial";
            RoundCounter = currentSceneIndex;
        }
        else if (RoundCounter != currentSceneIndex)
        {
            RoundTicker.text = $"Round {currentSceneIndex - 2}";
            RoundTicker.color = Color.blue;
            RoundCounter = currentSceneIndex;
            StartCoroutine(FadeOutRound());
        }
    }

    public void ProcessPlayerDeath()
    {
        if(PlayerLives > 1)
        {
            AudioSource.PlayClipAtPoint(DeathSFX, Camera.main.transform.position);
            StartCoroutine(LoadSameScene());
        }
        else
        {
            AudioSource.PlayClipAtPoint(DeathSFX, Camera.main.transform.position);
            PlayerLives--;
            LivesText.text = PlayerLives.ToString();
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void AddScore(int point)
    {
        Score += point;
        ScoreText.text = Score.ToString();
    }

    public IEnumerator FadeOutRound()
    {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f;
        RoundTicker.color = Color.clear;
    }


    IEnumerator LoadSameScene()
    {
        yield return new WaitForSecondsRealtime(LevelLoadDealy);
        Time.timeScale = 1f;
        TakeLives();
    }

    private void TakeLives()
    {
        PlayerLives--;
        LivesText.text = PlayerLives.ToString();
        Score = 0;
        ScoreText.text = Score.ToString();
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
