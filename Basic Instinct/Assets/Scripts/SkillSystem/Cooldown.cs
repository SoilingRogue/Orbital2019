using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.
public class Cooldown : MonoBehaviour
{
    public Image imageCooldown;
    public TextMeshProUGUI timer;
    public float cooldown = 5;
    public string button;
    private bool isCooldown;
    private float time;
    void Start()
    {
        time = cooldown;
    }
    void FixedUpdate()
    {
        if(Input.GetKeyDown(button) && !isCooldown)
        {
            isCooldown = true;
            imageCooldown.fillAmount = 1;
            // timer.text = "" + time;
        }

        if(isCooldown)
        {
            imageCooldown.fillAmount -= 1 / cooldown * Time.deltaTime;
            time -= Time.deltaTime;
            timer.text = "" + time;

            if(imageCooldown.fillAmount == 0)
            {
                isCooldown = false;
                timer.text = "";
                time = cooldown;
            }
        }
    }
}