using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownTracker : MonoBehaviour {
    public SkillBar skillBar;
    public List<Button> buttons;

    void Start() {
        
    }

    void Update() {
        for (int i = 0; i < skillBar.length(); i++) {
            Button button = buttons[i];
            UpdateButton script = button.GetComponent<UpdateButton>();
            script.updateText(skillBar.getHotkey(i));
            Skill skill = skillBar.getSkill(i);
            // NOTE: THIS IS UNRELIABLE!
            float cd = Time.time - skill.previousUseTime;
            cd = Mathf.Clamp(cd, 0, skill.cooldown);
            cd = cd / skill.cooldown;
            // END NOTE
            script.updatePanel(cd);
        }
    }
}
