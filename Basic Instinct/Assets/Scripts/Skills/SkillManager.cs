using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SkillManager : MonoBehaviour {
    public Skill[] skills;
    public KeyCode[] skillKeys;

    void Start() {
        skillKeys = new KeyCode[4];

        for (int i = 0; i < 4; i++) {
            skillKeys[i] = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Skill_" + i));
        }
    }

    void Update() {
        if (Input.anyKeyDown) {
            for (int i = 0; i < 4; i++) {
                if (Input.GetKeyDown(skillKeys[i])) {
                    Instantiate(skills[i].gameObject);
                    skills[i].useSkill();
                }
            }
        }
    }
}
