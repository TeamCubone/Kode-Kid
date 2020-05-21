using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Profiles for each individual
/// </summary>
public class AboutUsButton : MonoBehaviour
{
    public void JinProfile()
    {
        SceneManager.LoadScene("JinProfile");
    }
    public void BrandonProfile()
    {
        SceneManager.LoadScene("BrandonProfile");
    }

    public void HarryProfile()
    {
        SceneManager.LoadScene("HarryProfile");
    }

    public void AllyProfile()
    {
        Debug.Log("error");
        SceneManager.LoadScene("AllyProfile");
    }
}
