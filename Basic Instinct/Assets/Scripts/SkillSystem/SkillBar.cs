using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBar : MonoBehaviour {
    public KeyConfig keyConfig;
    public List<Skill> skillList;
    public List<KeyCode> keycodeList;
    public Dictionary<KeyCode, Skill> skillMap = new Dictionary<KeyCode, Skill>();

    void populateSkillMap() {
        for (int i = 0; i < skillList.Count; i++) {
            skillMap.Add(keycodeList[i], skillList[i]);
        }
    }
 
    void Start() {
        keyConfig = (KeyConfig)FindObjectOfType(typeof(KeyConfig));
        keycodeList = keyConfig.keyCodeList;

        // Debug.Log("skillList size: " + skillList.Count);
        populateSkillMap();
    }

    void Update() {
        if (Input.anyKeyDown) {
            // cycle through bound keys
            foreach (KeyCode key in skillMap.Keys) {
                if (Input.GetKeyDown(key)) {
                    skillMap[key].useSkill(gameObject);
                }
            }
        }
    }
}
