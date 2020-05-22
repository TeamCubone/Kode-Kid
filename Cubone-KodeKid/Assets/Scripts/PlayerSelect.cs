using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    private int selectedCharacterIndex;

    /// <summary>
    /// List of characters available
    /// </summary>
    [Header("List of Characters")]
    [SerializeField] private List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();

    /// <summary>
    /// Text and image according to the character
    /// </summary>
    [Header("UI References")]
    [SerializeField] private Text characterName;
    [SerializeField] private Image characterSplash;

    /// <summary>
    /// When start it will call method
    /// </summary>
    private void Start()
    {
        UpdateCharacterSelectionUI();
    }

    /// <summary>
    /// method to give life to left button
    /// </summary>
    public void Left()
    {
        selectedCharacterIndex--;
        if (selectedCharacterIndex < 0)
            selectedCharacterIndex = characterList.Count - 1;

        UpdateCharacterSelectionUI();
    }

    /// <summary>
    /// Method to give life to the right button
    /// </summary>
    public void Right()
    {
        selectedCharacterIndex++;
        if (selectedCharacterIndex >= characterList.Count)
            selectedCharacterIndex = 0;

        UpdateCharacterSelectionUI();
    }


    /// <summary>
    /// Changing the character according to the user's choice
    /// </summary>
    private void UpdateCharacterSelectionUI()
    {
        characterSplash.sprite = characterList[selectedCharacterIndex].splash;
        characterName.text = characterList[selectedCharacterIndex].characterName;
        characterName.color = characterList[selectedCharacterIndex].nameColor;
    }

    /// <summary>
    /// Event handler for confirm button
    /// </summary>
    public void Confirm()
    {
        PlayerPrefs.SetInt("Character", selectedCharacterIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Tutorial");
    }

    /// <summary>
    /// Menu button that will lead user back to main menu
    /// </summary>
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// constructor for this class
    /// </summary>
    [System.Serializable]
    public class CharacterSelectObject
    {
        public Sprite splash;
        public string characterName;
        public Color nameColor;
    }
}
