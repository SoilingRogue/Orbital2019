using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTutorial2 : Tutorial // Run tut
{
        public List<string> keys = new List<string>();

    public override void CheckIfHappening()
    {
        for (int i = 0; i < keys.Count; ++i)
        {
            if (Input.inputString.Contains(keys[i]) && Input.GetKey(KeyCode.LeftShift))
            {
                keys.RemoveAt(i);
                break;
            }
        }

        if (keys.Count == 0)
        // if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
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