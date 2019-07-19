using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBar : MonoBehaviour {
    public KeyConfig keyConfig;
    public List<Skill> skillList;
    public List<KeyCode> keycodeList;
    public Dictionary<KeyCode, Skill> skillMap = new Dictionary<KeyCode, Skill>();
    // private List<KeyCode> keycodes;

    void Start() {
        keyConfig = (KeyConfig)FindObjectOfType(typeof(KeyConfig));
        keycodeList = keyConfig.keyCodeList;

        // Debug.Log("skillList size: " + skillList.Count);
        populateSkillMap();

        // keycodes = new List<KeyCode>(4);
        // for (int i = 0; i < 4; i++) {
        //     string prefName = "Skill_" + (i + 1);
        //     string keycodetext = PlayerPrefs.GetString("prefName");
        //     KeyCode kc = (KeyCode)System.Enum.Parse(typeof(KeyCode), prefName);
        //     keycodes.Add(kc);
        // }
    }
 
    void Update() {
        if (Input.anyKeyDown) {
            // cycle through bound keys
            foreach (KeyCode key in skillMap.Keys) {
                if (Input.GetKeyDown(key)) {
                    skillMap[key].useSkill(gameObject);
                }
            }
            // foreach (KeyCode key in keycodes) {
            //     if (Input.GetKeyDown(key)) {
            //         skillMap[key].useSkill(gameObject);
            //     }
            // }
        }
    }

    void populateSkillMap() {
        for (int i = 0; i < skillList.Count; i++) {
            skillMap.Add(keycodeList[i], skillList[i]);
        }
    }

}
