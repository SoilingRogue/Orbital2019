using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBar : MonoBehaviour {
    // private List<Skill> skillList;
    // private List<KeyCode> keycodeList;
    public Dictionary<KeyCode, Skill> skillMap = new Dictionary<KeyCode, Skill>();

    // public KeyCode shield;
    // public KeyCode dagger;
    // public KeyCode teleport;
    // public KeyCode shockwave;

    // public Skill getSkill(int index) {
    //     try {
    //         return skillList[index];
    //     }
    //     catch (System.IndexOutOfRangeException e) {
    //         Debug.Log("No skill with given index {index}.");
    //         throw e;
    //     }
    // }

    // public string getHotkey(int index) {
        // return keycodeList[index].ToString();
    // }

    public int length() {
        return skillMap.Count;
        // return skillList.Count;
    }

    void Start() {
        skillMap.Add(KeyCode.Q, new Shield());
        skillMap.Add(KeyCode.E, new Dagger());
        skillMap.Add(KeyCode.R, new Teleport());
        skillMap.Add(KeyCode.T, new Shockwave());

        // skillList = new List<Skill>() {
        //         new Shield(),
        //         new Dagger(),
        //         new Teleport(),
        //         new Shockwave()
        // };
        // keycodeList = new List<KeyCode>(skillList.Count);

        // addSkillHotkey(shield, skillList[0]);
        // addSkillHotkey(dagger, skillList[1]);
        // addSkillHotkey(teleport, skillList[2]);
        // addSkillHotkey(shockwave, skillList[3]);
    }

    // void addSkillHotkey(KeyCode hotkey, Skill skill) {
        // keycodeList.Add(hotkey);
        // skillMap.Add(hotkey, skill);
    // }

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
