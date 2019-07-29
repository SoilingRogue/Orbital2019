using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour {
    private int sceneIndex;
    public TMP_Dropdown sceneDropdown;
    // public TMP_Dropdown characterDropdown;
    public Button button1;
    public Button button2;
    public Button button3;

    public TextMeshProUGUI skillDescriptionText;
    private GameObject selectedSkillButton;
    private List<string> sceneOptions;
    private List<string> characterOptions;

    void Start() {
        sceneOptions = new List<string>() {
            "Volcano",
            "Plane",
            "Halloween",
            "Sandbox"
        };
        sceneDropdown.ClearOptions();
        sceneDropdown.AddOptions(sceneOptions);

        int index = PlayerPrefs.GetInt("CharacterChoice", 0);
        switch (index) {
            case 0: button1.Select();
                break;
            case 1: button2.Select();
                break;
            case 2: button3.Select();
                break;
        }

        // characterOptions = new List<string>() {
        //     "Vanilla",
        //     "Halloween",
        //     "Schoolgirl"
        // };
        // characterDropdown.ClearOptions();
        // characterDropdown.AddOptions(characterOptions);
        // characterDropdown.value = PlayerPrefs.GetInt("CharacterChoice", 0);
        // characterDropdown.RefreshShownValue();
    }

    public void loadNextScene() {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void exitGame() {
        Debug.Log("Quit Game.");
        Application.Quit();
    }

    public void writeAllDefaultValues() {
       Animator[] anims = GameObject.FindObjectsOfType<Animator>();
       foreach (Animator anim in anims) {
           anim.WriteDefaultValues();
       }
    }

    public void stopBackgroundMusic() {
        AudioManager audioManager = GameManager.FindObjectOfType<AudioManager>();
        if (audioManager != null) {
            audioManager.Stop("ActionTime");
        }
    }

    public void setSceneIndex(int sceneIndex) {
        this.sceneIndex = sceneIndex;
    }

    public void setCharacterIndex(int characterIndex) {
        PlayerPrefs.SetInt("CharacterChoice", characterIndex);
    }

    public void selectSkillButton(GameObject button) {
        selectedSkillButton = button;
    }

    public void displaySkillDescription() {
        skillDescriptionText.text = selectedSkillButton.GetComponentInChildren<Text>().text;
    }
}
