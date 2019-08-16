using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial3 : Tutorial // Skill icons, cooldown, button to press etc
{
    public override void CheckIfHappening()
    {
        if (true)
        {
            GameObject gameObject = GameObject.Find("UnityChanTutorial");
            Debug.Log(gameObject);
            // GameObject varGameObject = GameObject.FindWithTag("Player"); then disable or enable script/component
            gameObject.GetComponent<PlayerMovement2>().enabled = true;

            TutorialManager.Instance.CompletedTutorial();
        }
    }
}