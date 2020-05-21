using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text text;
    private Color32 color;

    public void OnPointerEnter(PointerEventData eventData)
    {
        color = text.color;
        text.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = color;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("PlayerSelect");
    }

    public void StartLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }

    public void NotImplemented() 
    {
        color = Color.grey;
        Debug.Log("Not Implemented Yet.");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void AboutUs()
    {
        SceneManager.LoadScene("AboutUs");
    }



}
