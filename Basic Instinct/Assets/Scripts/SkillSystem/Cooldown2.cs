using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cooldown2 : MonoBehaviour
{
    public Image imageCooldown;
    public float cooldown = 5;
    public string button;
    protected bool isCooldown;


    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(button) && !isCooldown)
        {
            isCooldown = true;
            imageCooldown.fillAmount = 1;
        }

        if(isCooldown)
        {
            imageCooldown.fillAmount -= 1 / cooldown * Time.deltaTime;

            if(imageCooldown.fillAmount == 0)
            {
                isCooldown = false;
            }
        }
    }
}

