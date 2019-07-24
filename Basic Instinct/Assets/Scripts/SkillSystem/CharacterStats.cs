using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
    public GameManager gameManager;
    
    public int maxHealth;
    private int currentHealth;
    private bool isInvulnerable;
    public Animator animator;

    void Start() {
        currentHealth = maxHealth;
        Debug.Log(name + " has " + currentHealth + " health.");
    }

    public void takeDamage(int damage) {
        if (!isInvulnerable && currentHealth > 0) {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            Debug.Log(name + " takes " + damage + " damage.");
            Debug.Log(name + " has " + currentHealth + " health.");
            animator.SetBool("damaged", true);
        }
        // else if (currentHealth <= 0) {
            // Die();
            // Debug.Log(name + " is already dead.");
        // }
        else {
            Debug.Log("No damage taken. " + name + " is invulnerable.");
        }
        // Check if dead
        if (currentHealth <= 0) {
            die();
        }
    }

    public void setInvulnerable(float duration) {
        isInvulnerable = true;
        Debug.Log(name + " is now invulnerable.");
        Invoke("setVulnerable", duration);
    }

    private void setVulnerable() {
        isInvulnerable = false;
        Debug.Log(name + " is now vulnerable.");
    }

    private void die() {
        gameManager.lose();
    }
}
