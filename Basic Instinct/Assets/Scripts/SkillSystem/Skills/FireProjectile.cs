using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : Skill {
    public int damage;
    public float duration;
    public Vector3 diffVector;
    public float travelSpeed;
    private GameObject fireProjectile;
    private Vector3 direction;
    protected override void initialise() {
        skillName = "Fire Projectile";
        cooldown = 3f;
        // duration = 1.5f;
        // damage = 50;
        travelSpeed = 20f;
        diffVector = Vector3.up;
    }

    protected override void use() {
        direction = transform.forward.normalized;
        Vector3 spawnPosition = transform.position + diffVector;
        fireProjectile = Instantiate(visualPrefabs[0], spawnPosition, transform.rotation);

        DigitalRuby.PyroParticles.FireProjectileScript projectileScript = fireProjectile.GetComponentInChildren<DigitalRuby.PyroParticles.FireProjectileScript>();
            if (projectileScript != null)
            {
                // make sure we don't collide with other fire layers
                projectileScript.ProjectileCollisionLayers &= (~UnityEngine.LayerMask.NameToLayer("FireLayer"));
            }

        Collider projectileCollider = fireProjectile.GetComponentInChildren<Collider>();
        Collider userCollider = gameObject.GetComponent<Collider>();
        if (userCollider != null) {
            Physics.IgnoreCollision(projectileCollider, userCollider);
        }
        resetCooldown();
    }

    protected override void review() {
        
    }
}
