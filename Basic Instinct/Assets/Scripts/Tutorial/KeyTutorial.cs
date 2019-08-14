using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTutorial : Tutorial
{
    public List<string> keys = new List<string>();

    public override void CheckIfHappening()
    {
        for (int i = 0; i < keys.Count; ++i)
        {
            if (Input.inputString.Contains(keys[i]))
            {
                keys.RemoveAt(i);
                break;
            }
        }

        if (keys.Count == 0)
        {
            TutorialManager.Instance.CompletedTutorial();
        }
    }
}
