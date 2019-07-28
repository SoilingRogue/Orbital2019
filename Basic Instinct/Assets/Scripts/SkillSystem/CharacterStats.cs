using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
    private GameManager gameManager;
    public int maxHealth;
    public int currentHealth;
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
            die();
        }
    }

    public void setInvulnerable(float duration) {
        StartCoroutine(setInvulnerableHelper(duration));
    }

    private IEnumerator setInvulnerableHelper(float duration) {
        isInvulnerable = true;
        Debug.Log(name + " is now invulnerable.");
        yield return new WaitForSeconds(duration);
        isInvulnerable = false;
        Debug.Log(name + " is now vulnerable.");
    }

    public void die() {
        StartCoroutine(dieHelper());
    }

    private IEnumerator dieHelper() {
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
