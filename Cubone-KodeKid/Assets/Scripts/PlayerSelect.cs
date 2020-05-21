using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    private int selectedCharacterIndex;

    [Header("List of Characters")]
    [SerializeField] private List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();

    [Header("UI References")]
    [SerializeField] private Text characterName;
    [SerializeField] private Image characterSplash;

    private void Start()
    {
        UpdateCharacterSelectionUI();
    }

    public void Left()
    {
        selectedCharacterIndex--;
        if (selectedCharacterIndex < 0)
            selectedCharacterIndex = characterList.Count - 1;

        UpdateCharacterSelectionUI();
    }

    public void Right()
    {
        selectedCharacterIndex++;
        if (selectedCharacterIndex >= characterList.Count)
            selectedCharacterIndex = 0;

        UpdateCharacterSelectionUI();
    }

    private void UpdateCharacterSelectionUI()
    {
        characterSplash.sprite = characterList[selectedCharacterIndex].splash;
        characterName.text = characterList[selectedCharacterIndex].characterName;
        characterName.color = characterList[selectedCharacterIndex].nameColor;
    }

    public void Confirm()
    {
        PlayerPrefs.SetInt("Character", selectedCharacterIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Tutorial");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    [System.Serializable]
    public class CharacterSelectObject
    {
        public Sprite splash;
        public string characterName;
        public Color nameColor;
    }
}
