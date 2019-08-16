using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTutorial : Tutorial
{

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CheckIfHappening()
    {

        if (true)
        {
            TutorialManager.Instance.CompletedTutorial();
        }
    }
}
