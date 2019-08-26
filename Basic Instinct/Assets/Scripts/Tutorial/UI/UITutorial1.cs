using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial1 : Tutorial // Minimap tut
{
    private bool readyForNext;
    public GameObject gameObject2, gameObject3;

    public override void CheckIfHappening()
    {
        gameObject2.SetActive(true);
        gameObject3.SetActive(true);
        StartCoroutine(SetBoolean());
        if (readyForNext)
        {
            TutorialManager.Instance.CompletedTutorial();
        }
    }

    private IEnumerator SetBoolean() 
    {
        yield return new WaitForSeconds(7);
        readyForNext = true;
    }
}