using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Skill{
    private Camera cam;
    private float distance = 100f;
    private int layerMask;
    private RaycastHit hit;
    private GameObject ring;
    // public GameObject teleportRing1, teleportRing2;
    // private Light lt;

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
            // if (!position.Equals(raycast()) || fireRing == null)
            // {

            // }
            position.y = transform.position.y;
            if (ring == null) {
                // ring = Instantiate(teleportRing1, position, transform.rotation);
                ring = Instantiate(visualPrefabs[1], position, visualPrefabs[1].transform.rotation);
                // fireRing.transform.localScale *= 0.3f;
                // fireRing.GetComponentInChildren<AudioSource>().mute = true;
                // lt = fireRing.GetComponent<Light>();
            }
            else {
                // Set colour to bounce between blue and green
                // lt.color = Color.Lerp(Color.blue, Color.green, Mathf.PingPong(Time.time, 1));
                ring.transform.position = position;
            }
            yield return null;
        }
        
        teleport();
    }

    protected override void review()
    {

    }
    
    private void teleport()
    {
        Debug.Log("Teleporting.");
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        // transform.Translate(fireRing.transform.position);
        transform.position = ring.transform.position;
        Destroy(ring);

        GameObject fireRing = Instantiate(visualPrefabs[0], pos, rot);
        fireRing.transform.localScale *= 0.3f;
        fireRing.GetComponentInChildren<AudioSource>().mute = true;
        // transform.Translate(Vector3.forward * Time.deltaTime * distance);
        
        // fireRing.transform.position = pos;
        // lt.color = Color.red;
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