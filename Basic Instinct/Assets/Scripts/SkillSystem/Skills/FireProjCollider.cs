using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjCollider : MonoBehaviour {
    private void OnCollisionEnter(Collision other) {
        Debug.Log("Fire Projectile destroyed.");
        Destroy(gameObject);
    }
}
