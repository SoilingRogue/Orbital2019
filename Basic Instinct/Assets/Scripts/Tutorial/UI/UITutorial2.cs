using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial2 : Tutorial // Health, icons, timing etc tut
{
    public override void CheckIfHappening()
    {
        if (true)
        {
            TutorialManager.Instance.CompletedTutorial();
        }
    }
}