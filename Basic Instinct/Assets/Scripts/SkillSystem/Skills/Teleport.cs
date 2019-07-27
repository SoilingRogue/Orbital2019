using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Skill{
    private Camera cam;
    private float distance = 100f;
    private int layerMask;
    RaycastHit hit;
    private GameObject fireRing;

    void Start()
    {
        cam = Camera.main;
        layerMask = 1 << 2;
        layerMask = ~layerMask;
    }

    protected override void initialise()
    {
        skillName = "Teleport";
        cooldown = 0f;
    }

    protected override void use()
    {
        StartCoroutine(useHelper()); 
    }

    private IEnumerator useHelper() {
        while (Input.GetKey(key)) {
            Vector3 position = raycast();
            if (fireRing == null) {
                fireRing = Instantiate(visualPrefab, position, transform.rotation);
                fireRing.transform.localScale *= 0.3f;
                fireRing.GetComponentInChildren<AudioSource>().mute = true;
            }
            else {
                fireRing.transform.position = position;
            }
            yield return null;
        }
        Destroy(fireRing);
        teleport();
    }

    protected override void review()
    {

    }
    
    private void teleport()
    {
        Debug.Log("Teleporting.");
        fireRing = Instantiate(visualPrefab, transform.position, transform.rotation);
        fireRing.transform.localScale *= 0.5f;
        transform.Translate(Vector3.forward * Time.deltaTime * distance);
        Destroy(fireRing, 3);
    }

    private Vector3 raycast()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit, 500f, layerMask))
        {
            Debug.Log("Ray hit " + hit.transform.name);
        }
        
        Debug.Log("Ray hit distance: " + hit.distance);

        return hit.point;
    }
}