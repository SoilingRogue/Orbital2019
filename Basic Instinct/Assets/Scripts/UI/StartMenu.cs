using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour {
    private int sceneIndex;
    public TMP_Dropdown sceneDropdown;
    public TextMeshProUGUI skillDescriptionText;
    private GameObject selectedSkillButton;
    private List<string> sceneOptions;

    void Start() {
        sceneOptions = new List<string>() {
            "Volcano",
            "Plane",
            "Halloween"
        };
        sceneDropdown.ClearOptions();
        sceneDropdown.AddOptions(sceneOptions);
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

    public void selectSkillButton(GameObject button) {
        selectedSkillButton = button;
    }

    public void displaySkillDescription() {
        skillDescriptionText.text = selectedSkillButton.GetComponentInChildren<Text>().text;
    }
}
