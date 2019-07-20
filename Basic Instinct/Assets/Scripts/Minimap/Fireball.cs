using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    private Vector3 direction;
    private float travelSpeed = 10f;
    private int damage = 20;

    public void setDirection(Vector3 direction) {
        this.direction = direction;
    }

    void Start() {
        MeshFilter meshFilter = (MeshFilter)gameObject.AddComponent(typeof(MeshFilter));

        // This is a hack
        GameObject tempSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        meshFilter.mesh = tempSphere.GetComponent<MeshFilter>().mesh;
        GameObject.Destroy(tempSphere);

        gameObject.AddComponent(typeof(MeshRenderer));

        Rigidbody body = (Rigidbody)gameObject.AddComponent(typeof(Rigidbody));
        body.useGravity = false;

        Collider collider = (Collider)gameObject.AddComponent(typeof(SphereCollider));
        collider.isTrigger = true;
    }   

    void Update() {
        // Normalize direction vector so that the speed of the projectile is independent
        // of the distance between the enemy and the player.
        transform.position += direction.normalized * Time.deltaTime * travelSpeed;
    }

    void OnTriggerEnter(Collider other) {
        GameObject obj = other.gameObject;
        if (obj.CompareTag("Player")) {
            Debug.Log("Fireball Collided.");    
            CharacterStats playerStats = obj.GetComponent<CharacterStats>();
            playerStats.takeDamage(damage);
        }
    }
}
