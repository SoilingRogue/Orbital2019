﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTutorial1 : Tutorial // Walk tut
{
    public List<string> keys = new List<string>();
    public GameObject gameObject2;

    public override void CheckIfHappening()
    {
        gameObject2.SetActive(true);
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
            gameObject2.SetActive(false);
            GameObject gameObject = GameObject.Find("UnityChanTutorial");
            Debug.Log(gameObject);
            // GameObject varGameObject = GameObject.FindWithTag("Player"); then disable or enable script/component
            gameObject.GetComponent<TutorialMovement2>().enabled = true;
            gameObject.GetComponent<TutorialMovement1>().enabled = false;
            
            TutorialManager.Instance.CompletedTutorial();
        }
    }
}