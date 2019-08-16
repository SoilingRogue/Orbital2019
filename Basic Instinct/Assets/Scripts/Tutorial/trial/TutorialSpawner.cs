using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawner : MonoBehaviour
{
    public GameObject enemy;
    public float startTimeBtwMonster;
    private float timeBtwMonster;
    public int numMonster;

    // Update is called once per frame
    void Update()
    {
        if (timeBtwMonster <= 0 && numMonster> 0)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            timeBtwMonster = startTimeBtwMonster;
            numMonster--;
        }
        else 
        {
            timeBtwMonster -= Time.deltaTime;
        }
    }
}
