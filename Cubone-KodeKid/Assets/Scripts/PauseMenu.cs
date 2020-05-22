using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /// <summary>
    ///  Using this to pause the game this variable is false to start
    /// </summary>
    public static bool GameIsPaused = false;

    /// <summary>
    ///  when user press on escape, it will trigger pause and show buttons
    /// </summary>
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Resume when user clicks on resume
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    /// <summary>
    /// User is stopped due to the pause
    /// </summary>
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    /// <summary>
    /// when load to the menu it will destroy canvas and back to the main menu
    /// </summary>
    public void LoadMenu()
    {
        Destroy(GameObject.FindWithTag("GameSesh"));
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Quitting the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
