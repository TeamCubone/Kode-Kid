using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>
    /// Local Properties that will set text and color of the text
    /// </summary>
    public Text text;
    private Color32 color;

    /// <summary>
    /// When mouse is hovered over it will show white text
    /// </summary>
    /// <param name="eventData">event trigger</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        color = text.color;
        text.color = Color.white;
    }

    /// <summary>
    /// It willthen turn back the color whn its hovered out
    /// </summary>
    /// <param name="eventData">event trigger</param>
    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = color;
    }

    /// <summary>
    /// Leading to player select
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("PlayerSelect");
    }

    /// <summary>
    /// It will lead user to certain level
    /// </summary>
    /// <param name="level">level you want the user to go</param>
    public void StartLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    /// <summary>
    /// Quitting he application
    /// </summary>
    public void ApplicationQuit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Changing the color to grey
    /// </summary>
    public void NotImplemented() 
    {
        color = Color.grey;
        Debug.Log("Not Implemented Yet.");
    }

    /// <summary>
    /// Leading to the main menu
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Leading to about us page
    /// </summary>
    public void AboutUs()
    {
        SceneManager.LoadScene("AboutUs");
    }



}
