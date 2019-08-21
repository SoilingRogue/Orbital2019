using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTutorial1 : Tutorial // MouseMovement tut
{
    private bool readyForNext;
    public GameObject gameObject2;

    public override void CheckIfHappening()
    {
        gameObject2.SetActive(true);
        StartCoroutine(SetBoolean());
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            if (readyForNext) 
            {
                gameObject2.SetActive(false);
                TutorialManager.Instance.CompletedTutorial();
            }
        }
    }
    
    private IEnumerator SetBoolean() 
    {
        yield return new WaitForSeconds(5);
        readyForNext = true;
    }
}