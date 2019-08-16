using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTutorial : Tutorial // Intro words to show before tutorial officially starts
{
    public override void CheckIfHappening()
    {

        if (true)
        {
            TutorialManager.Instance.CompletedTutorial();
        }
    }
}
