using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    /// <summary>
    /// Game session class that will carry players lives, score and other variable that will track player's status
    /// </summary>
    [SerializeField] int PlayerLives = 3;
    [SerializeField] int Score = 0;
    [SerializeField] Text LivesText;
    [SerializeField] Text ScoreText;
    [SerializeField] float LevelLoadDealy = 2f;
    [SerializeField] AudioClip DeathSFX;
    [SerializeField] public Text RoundTicker;
    public int RoundCounter;

    /// <summary>
    /// This will allow user to have three lives and upon three death it will destroy the world
    /// </summary>
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

    /// <summary>
    /// This will check if our round is being render correctly. and also handles the fade out of round text
    /// </summary>
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

    /// <summary>
    /// Getting the death to decrement upon death and let the user see the gameover scene if they die
    /// </summary>
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

    /// <summary>
    /// Adding the score, if player picks up coins
    /// </summary>
    /// <param name="point"></param>
    public void AddScore(int point)
    {
        Score += point;
        ScoreText.text = Score.ToString();
    }

    /// <summary>
    /// Fading out the each round
    /// </summary>
    /// <returns></returns>
    public IEnumerator FadeOutRound()
    {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f;
        RoundTicker.color = Color.clear;
    }

    /// <summary>
    /// Loading to the next scene.
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadSameScene()
    {
        yield return new WaitForSecondsRealtime(LevelLoadDealy);
        Time.timeScale = 1f;
        TakeLives();
    }

    /// <summary>
    /// Tkaing the life when player collide to hazard or enemy
    /// </summary>
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
