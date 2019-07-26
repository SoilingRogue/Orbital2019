using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Skill{
    public KeyCode key;
    private Camera cam;
    private float distance = 100f;
    private int layerMask;
RaycastHit hit;
    void Start()
    {
        cam = Camera.main;
        // layerMask = 1 << 0;
        // layerMask = ~layerMask;
        layerMask = ~2;
    }

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
        cooldown = 0f;
    }

    protected override void use()
    {
        // Debug.Log(Camera.main);

        raycast();

        if(Input.GetKeyUp(key))
        {
            teleport();
        }
    }

    protected override void review()
    {

    }
    
    private void teleport()
    {
        GameObject fireRing = Instantiate(visualPrefab, transform.position, transform.rotation);
        fireRing.transform.localScale = fireRing.transform.localScale * 0.5f;
        transform.Translate(Vector3.forward * Time.deltaTime * distance);
        Destroy(fireRing, 3);
    }

    private void raycast()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit, 200f, layerMask))
        {
            Debug.Log(hit.transform.name);
        }
        // Physics.Raycast(ray, out hit, 200f);
        
        Debug.Log(hit.distance);
    }
}