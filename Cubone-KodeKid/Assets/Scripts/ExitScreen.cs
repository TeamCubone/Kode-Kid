using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScreen : MonoBehaviour
{
    /// <summary>
    /// When finishing the game it will destroy the gamesession.
    /// </summary>
    public void EndTheGame()
    {
        Destroy(GameObject.FindWithTag("GameSesh"));
        SceneManager.LoadScene("Winning Screen");
    }

}
