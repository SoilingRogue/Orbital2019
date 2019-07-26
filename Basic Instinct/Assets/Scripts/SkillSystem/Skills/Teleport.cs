using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Skill {
    private float distance = 100f;
//     // Constructor
//     void Start() {
//         name = "Teleport";
//         cooldown = 5f;
//         // previousUseTime = -cooldown;
//     }

//     protected override void use(GameObject character) {
//         CharacterStats stats = character.GetComponent<CharacterStats>();
//         character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, character.transform.position.z + 30);

//         display(character);
//     }

//     private void display(GameObject character) {

//     }
    protected override void initialise()
    {
        skillName = "Teleport";
        cooldown = 8f;  
    }

    protected override void use()
    {
        GameObject fireRing = Instantiate(visualPrefab, transform.position, transform.rotation);
        fireRing.transform.localScale = fireRing.transform.localScale * 0.5f;
        transform.Translate(Vector3.forward * Time.deltaTime * distance);
        Destroy(fireRing, 3);
    }
    
    protected override void review()
    {

    }
}