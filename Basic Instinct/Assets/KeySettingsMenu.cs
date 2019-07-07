using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeySettingsMenu : MonoBehaviour {
    // public TMP_Text buttonText;
    private Button buttonPressed;
    public void changeKey(Button self) {
        Debug.Log("Key selected.");
        buttonPressed = self;
    }

    void OnGUI() {
        Event ev = Event.current;
        if (ev.isKey) {
            try {
                TMP_Text buttonText = buttonPressed.transform.GetChild(0).GetComponent<TMP_Text>();
                buttonText.text = ev.keyCode.ToString();
                buttonPressed = null;
            }
            catch (NullReferenceException e) {
                Debug.Log("No button selected.");
                Debug.Log(e.StackTrace);
                throw e;
            }
        }
    }
}
