using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTutorial2 : Tutorial // Run tut
{
    public override void CheckIfHappening()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            GameObject gameObject = GameObject.Find("UnityChanTutorial");
            Debug.Log(gameObject);
            // GameObject varGameObject = GameObject.FindWithTag("Player"); then disable or enable script/component
            gameObject.GetComponent<TutorialMovement3>().enabled = true;
            gameObject.GetComponent<TutorialMovement2>().enabled = false;

            TutorialManager.Instance.CompletedTutorial();
        }
    }
}