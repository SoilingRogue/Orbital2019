using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTutorial1 : Tutorial // MouseMovement tut
{
    public override void CheckIfHappening()
    {

        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            TutorialManager.Instance.CompletedTutorial();
        }
    }
}