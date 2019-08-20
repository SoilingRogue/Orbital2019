using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTutorial2 : Tutorial // MouseScroll tut
{
    private bool readyForNext;

    public override void CheckIfHappening()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            StartCoroutine(SetBoolean());
            if (readyForNext)
            {
                GameObject gameObject = GameObject.Find("UnityChanTutorial");
                Debug.Log(gameObject);
                // GameObject varGameObject = GameObject.FindWithTag("Player"); then disable or enable script/component
                gameObject.GetComponent<TutorialMovement1>().enabled = true;

                TutorialManager.Instance.CompletedTutorial();
            }
        }
    }

    private IEnumerator SetBoolean() 
    {
        yield return new WaitForSeconds(3);
        readyForNext = true;
    }
}