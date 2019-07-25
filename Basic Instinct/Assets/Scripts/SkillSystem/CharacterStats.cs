using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
    private GameManager gameManager;
    public int maxHealth;
    private int currentHealth;
    private bool isInvulnerable;
    public Animator animator;

    void Start() {
        currentHealth = maxHealth;
        Debug.Log(name + " has " + currentHealth + " health.");
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void takeDamage(int damage) {
        if (!isInvulnerable && currentHealth > 0) {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            Debug.Log(name + " takes " + damage + " damage.");
            Debug.Log(name + " has " + currentHealth + " health.");
            animator.Play("DAMAGED00");
        }
        else {
            Debug.Log("No damage taken. " + name + " is invulnerable.");
        }
        // Check if dead
        if (currentHealth <= 0) {
            StartCoroutine(die());
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

    private IEnumerator die() {
        animator.Play("DAMAGED01");
        if (gameManager != null) {
            yield return new WaitForSeconds(2);
            gameManager.lose();
        }
        else {
            Debug.LogWarning("No GameManager in scene.");
        }
    }
}
