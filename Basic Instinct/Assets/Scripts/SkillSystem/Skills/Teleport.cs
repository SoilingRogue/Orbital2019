using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Skill{
    public GameObject projectThru;
    private Camera cam;
    private float distance = 100f;
    private int layerMask;
    private RaycastHit hit;
    private GameObject ring;
    private Animator anim;

    void Start()
    {
        cam = Camera.main;
        layerMask = 1 << 2;
        layerMask = ~layerMask;
        anim = gameObject.GetComponent<Animator>();
        projectThru = cam.transform.parent.gameObject;
    }

    protected override void initialise()
    {
        skillName = "Teleport";
        cooldown = 4f;
    }

    protected override void use()
    {
        anim.SetBool("skill", true);
        StartCoroutine(useHelper()); 
    }

    private IEnumerator useHelper() {
        while (Input.GetKey(key)) {
            Vector3 position = raycast();
            position.y = transform.position.y;
            if (ring == null) {
                // ring = Instantiate(visualPrefabs[1], position, visualPrefabs[1].transform.rotation);
                ring = Instantiate(visualPrefabs[2], position, visualPrefabs[2].transform.rotation);
            }
            else {
                ring.transform.position = position;
            }
            yield return null;
        }
        
        teleport();
    }

    private IEnumerator setBool() 
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("skill", false);
    }

    protected override void review()
    {

    }
    
    private void teleport()
    {
        Debug.Log("Teleporting.");
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        transform.position = ring.transform.position;
        Destroy(ring);

        GameObject fireRing = Instantiate(visualPrefabs[0], pos, rot);
        fireRing.transform.localScale *= 0.3f;
        fireRing.GetComponentInChildren<AudioSource>().mute = true;
        
        Destroy(fireRing, 3);
        StartCoroutine(setBool()); 
    }

    private Vector3 raycast()
    {
        // Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 viewPortPos = cam.WorldToViewportPoint(projectThru.transform.position);
        Ray ray = cam.ViewportPointToRay(viewPortPos);

        if (Physics.Raycast(ray, out hit, 500f, layerMask))
        {
            Debug.Log("Ray hit " + hit.transform.name);
        }
        
        Debug.Log("Ray hit distance: " + hit.distance);

        return hit.point;
    }
}