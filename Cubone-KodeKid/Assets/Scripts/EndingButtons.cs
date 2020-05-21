using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingButtons : MonoBehaviour
{
    /// <summary>
    /// Finishing the application
    /// </summary>
    public void ApplicationFinish()
    {
        Application.Quit();
    }

    /// <summary>
    /// Loading the scene to About us page when clicked
    /// </summary>
    public void AboutUs()
    {
        SceneManager.LoadScene("AboutUs");
    }
}
