using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial1 : Tutorial // Minimap tut
{
    public override void CheckIfHappening()
    {
        if (true)
        {
            TutorialManager.Instance.CompletedTutorial();
        }
    }
}