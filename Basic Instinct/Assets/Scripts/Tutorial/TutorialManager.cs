using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public List<Tutorial> tutorials = new List<Tutorial>();
    public TextMeshProUGUI expText;
    private static TutorialManager instance;
    public static TutorialManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<TutorialManager>();

            // To check if the first assignment failed - meaning that no tutorial manager is present
            if (instance == null)
                Debug.Log("No Tutorial Manager present");

            return instance;
        }
    }
    private Tutorial currentTutorial;


    // Start is called before the first frame update
    void Start()
    {
        SetNextTutorial(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTutorial)
        {
            currentTutorial.CheckIfHappening();
        }
    }

    public void CompletedTutorial()
    {
        SetNextTutorial(currentTutorial.order + 1);
    }

    // Get next tutorial
    public Tutorial GetTutorialByOrder(int order)
    {
        for (int i = 0; i < tutorials.Count; ++i) 
        {
            Tutorial temp = tutorials[i];
            if (temp.order == order)
            {
                return temp;
            }
        }

        return null;
    }

    // Set
    public void SetNextTutorial(int order)
    {
        currentTutorial = GetTutorialByOrder(order);

        // Check if empty
        if (!currentTutorial)
        {
            CompletedAllTutorials();
            return;
        }
        
        expText.text = currentTutorial.explanation;
    }

    public void CompletedAllTutorials()
    {
        expText.text = "Completed all tuts";

        // loadscene
    }
}