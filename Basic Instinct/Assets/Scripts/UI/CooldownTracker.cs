using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownTracker : MonoBehaviour {
    public SkillBar skillBar;
    public List<Button> buttons;

    void Update() {
        for (int i = 0; i < skillBar.skillMap.Count; i++) {
            Button button = buttons[i];
            UpdateButton buttonScript = button.GetComponent<UpdateButton>();
            buttonScript.trackedSkill = skillBar.skillList[i];
            buttonScript.displayedKey = skillBar.keycodeList[i];
        }
    }
}
