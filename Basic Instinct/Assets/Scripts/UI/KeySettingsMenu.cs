using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeySettingsMenu : MonoBehaviour {
    public TMP_Text errorMessage;
    private int numberOfSkills = 4;
    private Button buttonPressed;
    private Color unpressedColor = new Color32(255, 255, 255, 255);
    private Color pressedColor = new Color32(0, 0, 0, 100);

    void Start() {
        if (PlayerPrefs.GetString("Skill_0") == "") {
            PlayerPrefs.SetString("Skill_0", "Q");
        }
        if (PlayerPrefs.GetString("Skill_1") == "") {
            PlayerPrefs.SetString("Skill_1", "E");
        }
        if (PlayerPrefs.GetString("Skill_2") == "") {
            PlayerPrefs.SetString("Skill_2", "R");
        }
        if (PlayerPrefs.GetString("Skill_3") == "") {
            PlayerPrefs.SetString("Skill_3", "F");
        }

        // Display the previously binded keys
        for (int i = 0; i < numberOfSkills; i++) {
            TMP_Text buttonText = transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
            buttonText.text = PlayerPrefs.GetString("Skill_" + i);
            // buttonText.text = keyConfig.keyCodeList[i].ToString();
        }
    }

    public void changeKey(Button self) {
        Debug.Log("Key selected.");
        // If another button was pressed previously, change its state back to normal
        if (buttonPressed != null) {
            buttonPressed.GetComponent<Image>().color = unpressedColor;
        }
        buttonPressed = self;

        // Change color
        Image buttonImage = buttonPressed.GetComponent<Image>();
        buttonImage.color = pressedColor;
    }

    public void saveKeys() {
        Debug.Log("Saving keys.");
        
        // Copy the button texts into a list of keycodes
        for (int i = 0; i < numberOfSkills; i++) {
            // Extract the set string from corresponding button
            string keyCodeText = transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text;

            // Check if key code already in the list
            if (keyAlreadyBinded(keyCodeText)) {
                string errorText = "You cannot use the " + keyCodeText + " key";
                displayErrorMessage(errorText);
                // throw exception to prevent execution of the next two button functions
                throw new ArgumentException(errorText);
            }
            else if (isDuplicated(keyCodeText, i)) {
                string errorText = "You cannot use duplicate keys";
                displayErrorMessage(errorText);
                // throw exception to prevent execution of the next two button functions
                throw new ArgumentException(errorText);
            }
            else {
                // Use PlayerPrefs
                PlayerPrefs.SetString("Skill_" + i, keyCodeText);
            }
        }
    }

    void displayErrorMessage(string errorText) {
        errorMessage.text = errorText;
        errorMessage.gameObject.SetActive(true);
        CancelInvoke("hideErrorMessage");
        Invoke("hideErrorMessage", 3);
    }

    void hideErrorMessage() {
        errorMessage.gameObject.SetActive(false);
    }

    bool isDuplicated(string keyCodeText, int index) {
        for (int i = 0; i < numberOfSkills; i++) {
            if (i != index) {
                if (keyCodeText == PlayerPrefs.GetString("Skill_" + i)) {
                    return true;
                }
            }
        }
        return false;
    }

    bool keyAlreadyBinded(string keyCodeText) {
        KeyCode kc = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyCodeText);
        List<KeyCode> bindedKeyTexts = new List<KeyCode>() {
            KeyCode.W,
            KeyCode.A,
            KeyCode.S,
            KeyCode.D,
            KeyCode.T,
            KeyCode.G,
            KeyCode.Escape,
            KeyCode.Alpha0,
            KeyCode.Alpha1,
            KeyCode.Space,
            KeyCode.LeftShift,
            KeyCode.LeftControl,
            KeyCode.CapsLock
        };
        return bindedKeyTexts.Contains(kc); 
    }

    void OnGUI() {
        Event ev = Event.current;
        if (ev.isKey) {
            if (buttonPressed != null) {
                TMP_Text buttonText = buttonPressed.transform.GetChild(0).GetComponent<TMP_Text>();
                buttonText.text = ev.keyCode.ToString();

                // Change back color
                Image buttonImage = buttonPressed.GetComponent<Image>();
                buttonImage.color = unpressedColor;

                buttonPressed = null;
            }
        }
    }

    public void writeAllDefaultValues() {
       Animator[] anims = GameObject.FindObjectsOfType<Animator>();
       foreach (Animator anim in anims) {
           anim.WriteDefaultValues();
       }
    }
}
