using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SkillManager : MonoBehaviour {
    public SkillHelper[] skillHelpers;
    public KeyCode[] skillKeys;
    private List<Skill> skills;

    void Awake() {
        bindSkillKeys();
        bindSkills();
    }

    void Update() {
        if (Input.anyKeyDown) {
            for (int i = 0; i < 4; i++) {
                if (Input.GetKeyDown(skillKeys[i])) {
                    if (i < skills.Count) {
                        skills[i].useSkill();
                    }
                }
            }
        }
    }

    void bindSkillKeys() {
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

        skillKeys = new KeyCode[4];

        for (int i = 0; i < 4; i++) {
            skillKeys[i] = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Skill_" + i));
        }
    }

    void bindSkills() {
        skills = new List<Skill>();

        for (int i = 0; i < skillHelpers.Length; i++) {
            SkillHelper skillHelper = skillHelpers[i];
            Type skillType = skillHelper.skill.GetType();
            Skill skillComponent = (Skill)skillHelper.user.AddComponent(skillType);
            skillComponent.visualPrefabs = skillHelper.visuals;
            skillComponent.key = skillKeys[i];
            skills.Add(skillComponent);
        }
    }

    public Skill getSkill(int index) {
        if (index < skills.Count) {
            return skills[index];
        }
        else {
            return null;
        }
    }

    public string getSkillKey(int index) {
        return skillKeys[index].ToString();
    }
}
