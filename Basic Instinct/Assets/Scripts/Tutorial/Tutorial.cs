using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public int order;
    public string explanation;

    // Awake called before Start()
    void Awake()
    {
        // Adds all tutorials in the scene to the TutorialManager when game starts
        TutorialManager.Instance.tutorials.Add(this);
    }

    public virtual void CheckIfHappening() {}
}
