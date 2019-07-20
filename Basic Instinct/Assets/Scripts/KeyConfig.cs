using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyConfig : MonoBehaviour {
    public List<KeyCode> keyCodeList;

    void Start() {
        setDefaultKeys();
    }

    public void updateKeys(List<KeyCode> keyCodeList) {
        this.keyCodeList = keyCodeList;
    }

    private void setDefaultKeys() {
        keyCodeList = new List<KeyCode>() {
            KeyCode.Q,
            KeyCode.E,
            KeyCode.R,
            KeyCode.F
        };
    }
}
