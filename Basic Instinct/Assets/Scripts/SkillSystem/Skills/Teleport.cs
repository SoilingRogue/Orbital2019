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
        layerMask = 1 << 2;
        layerMask = ~layerMask;
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

        Vector3 position = raycast();
        GameObject fireRing = Instantiate(visualPrefab, position, transform.rotation);
        fireRing.transform.localScale = fireRing.transform.localScale * 0.3f;
        if(Input.GetKeyUp(key))
        {
            Destroy(fireRing);
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

    private Vector3 raycast()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit, 500f, layerMask))
        {
            Debug.Log(hit.transform.name);
        }
        
        Debug.Log(hit.distance);

        return hit.point;
    }
}