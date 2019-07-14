﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeySettingsMenu : MonoBehaviour {
    public TMP_Text errorMessage;
    private int numberOfSkills = 4;
    private List<string> keyCodeStringList;
    private List<KeyCode> keyCodeList;
    private Button buttonPressed;

    public void changeKey(Button self) {
        Debug.Log("Key selected.");
        buttonPressed = self;

        // Change color
        Image buttonImage = buttonPressed.GetComponent<Image>();
        buttonImage.color = new Color32(0, 0, 0, 100);
    }

    public void saveKeys() {
        Debug.Log("Saving keys.");

        // Reinitialise both lists
        keyCodeStringList = new List<string>(numberOfSkills);
        keyCodeList = new List<KeyCode>(numberOfSkills);
        
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
            else if (keyCodeStringList.Contains(keyCodeText)) {
                string errorText = "You cannot use duplicate keys";
                displayErrorMessage(errorText);
                // throw exception to prevent execution of the next two button functions
                throw new ArgumentException(errorText);
            }
            else {
                keyCodeStringList.Add(keyCodeText);
            }
        }

        // Converts the string to actual key code object
        keyCodeStringList.ForEach(str => keyCodeList.Add((KeyCode)System.Enum.Parse(typeof(KeyCode), str)));
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

    bool keyAlreadyBinded(string keyCodeText) {
        List<string> bindedKeyTexts = new List<string>() {
            "W",
            "A",
            "S",
            "D",
            "Escape"
        };
        return bindedKeyTexts.Contains(keyCodeText); 
    }

    void OnGUI() {
        Event ev = Event.current;
        if (ev.isKey) {
            if (buttonPressed != null) {
                TMP_Text buttonText = buttonPressed.transform.GetChild(0).GetComponent<TMP_Text>();
                buttonText.text = ev.keyCode.ToString();

                // Change back color
                Image buttonImage = buttonPressed.GetComponent<Image>();
                buttonImage.color = new Color(255, 255, 255, 255);

                buttonPressed = null;
            }
        }
    }
}
