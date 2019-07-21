using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownHandler : MonoBehaviour {
    public SkillManager skillManager;
    void Start() {
        skillManager = GameObject.FindObjectOfType<SkillManager>();
        if (skillManager == null) {
            Debug.LogWarning("Skill Manager does not exist in this scene.");
            return;
        }

        Cooldown[] cooldowns = transform.GetComponentsInChildren<Cooldown>(false);
        for (int i = 0; i < cooldowns.Length; i++) {
            Cooldown cd = cooldowns[i];
            cd.skill = skillManager.getSkill(i);
            cd.button = skillManager.getSkillKey(i);
        }
    }
}
