using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    void Start() {
        Animator[] animators = GameObject.FindObjectsOfType<Animator>();
        foreach (Animator animator in animators) {
            animator.WriteDefaultValues();
        }
    }

    public void loadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exitGame() {
        Debug.Log("Quit Game.");
        Application.Quit();
    }
}
