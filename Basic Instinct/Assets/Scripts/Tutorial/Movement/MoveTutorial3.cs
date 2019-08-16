using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTutorial3 : Tutorial // Slide & jump tut
{
    private bool slide, jump;

    public override void CheckIfHappening()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            slide = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (slide && jump)
        {
            // GameObject gameObject = GameObject.Find("UnityChanTutorial");
            // Debug.Log(gameObject);
            // // GameObject varGameObject = GameObject.FindWithTag("Player"); then disable or enable script/component
            // gameObject.GetComponent<PlayerMovement2>().enabled = true;
            // gameObject.GetComponent<TutorialMovement3>().enabled = false;

            TutorialManager.Instance.CompletedTutorial();
        }
    }
}