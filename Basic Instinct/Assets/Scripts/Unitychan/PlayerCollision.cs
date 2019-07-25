using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    public CharacterStats stats;
    public int damagePerHit;

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy")) {
            Debug.Log(name + " collided with " + other.gameObject.name);
            stats.takeDamage(damagePerHit);
            stats.setInvulnerable(1);
        }
    }
}
