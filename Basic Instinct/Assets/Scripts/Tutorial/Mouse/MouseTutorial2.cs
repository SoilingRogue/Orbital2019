using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTutorial2 : Tutorial // MouseScroll tut
{
    public override void CheckIfHappening()
    {

        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            GameObject gameObject = GameObject.Find("UnityChanTutorial");
            Debug.Log(gameObject);
            // GameObject varGameObject = GameObject.FindWithTag("Player"); then disable or enable script/component
            gameObject.GetComponent<TutorialMovement1>().enabled = true;

            TutorialManager.Instance.CompletedTutorial();
        }
    }
}