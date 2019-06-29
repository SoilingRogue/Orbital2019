using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    private Vector3 direction;
    private float travelSpeed = 2f;

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
    }   

    void Update() {
        transform.position += direction * Time.deltaTime * travelSpeed;
    }
}
