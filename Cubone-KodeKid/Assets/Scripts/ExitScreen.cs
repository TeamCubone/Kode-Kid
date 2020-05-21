using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScreen : MonoBehaviour
{
    public void EndTheGame()
    {
        Destroy(GameObject.FindWithTag("GameSesh"));
        SceneManager.LoadScene("Winning Screen");
    }

}
