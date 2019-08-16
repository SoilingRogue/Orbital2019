using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager2 : MonoBehaviour
{
    public GameObject[] popup;
    public GameObject spawner;
    private int popupIndex;

    void Update()
    {
        for (int i = 0; i < popup.Length; i++)
        {
            if (i == popupIndex)
            {
                popup[i].SetActive(true);
            }
            else
            {
                popup[i].SetActive(false);
            }
        }
        if (popupIndex == 0) // Panning
        {

            popupIndex++;            
        }        
        else if (popupIndex == 1) // Changing camera zoom
        {

            popupIndex++;
        }
        else if (popupIndex == 2) // Moving
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                popupIndex++;
            }
        }
        else if (popupIndex == 3) // Running
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
            {
                popupIndex++;
            }
        }        
        else if (popupIndex == 4) // Jumping & sliding
        {
            bool slide = false, jump = false;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftControl) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
            {
                slide = true;
            }

            if (slide && jump)
            {
                popupIndex++;
            }
        }
        else if (popupIndex == 5) // Fireball skill
        {
            spawner.SetActive(true);
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                popupIndex++;
            }
        }
    }
}
