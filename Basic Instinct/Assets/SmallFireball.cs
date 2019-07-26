using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallFireball : MonoBehaviour {
    public float speed;
    public float duration;
    public Vector3 direction;

    void Start() {
        Destroy(gameObject, duration);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }

    void Update() {
        transform.position += direction * Time.deltaTime * speed;
    }
}
