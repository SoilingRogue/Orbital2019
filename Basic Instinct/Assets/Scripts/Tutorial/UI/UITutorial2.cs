﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial2 : Tutorial // Health, icons, timing etc tut
{
    private bool readyForNext;

    public override void CheckIfHappening()
    {
        StartCoroutine(SetBoolean());
        if (readyForNext)
        {
            TutorialManager.Instance.CompletedTutorial();
        }
    }

    private IEnumerator SetBoolean() 
    {
        yield return new WaitForSeconds(10);
        readyForNext = true;
    }
}