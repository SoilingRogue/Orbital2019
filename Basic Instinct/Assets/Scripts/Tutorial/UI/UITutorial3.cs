using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial3 : Tutorial // Skill icons, cooldown, button to press etc
{
    private bool readyForNext;
    public GameObject gameObject2;

    public override void CheckIfHappening()
    {
        gameObject2.SetActive(true);
        StartCoroutine(SetBoolean());
        if (readyForNext)
        {
                        GameObject gameObject = GameObject.Find("UnityChanTutorial");
            // Debug.Log(gameObject);
            // // GameObject varGameObject = GameObject.FindWithTag("Player"); then disable or enable script/component
            gameObject.GetComponent<PlayerMovement2>().enabled = true;
            gameObject.GetComponent<TutorialMovement3>().enabled = false;
            TutorialManager.Instance.CompletedTutorial();
        }
    }

    private IEnumerator SetBoolean() 
    {
        yield return new WaitForSeconds(7);
        readyForNext = true;
    }
}