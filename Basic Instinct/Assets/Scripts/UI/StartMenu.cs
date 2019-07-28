using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    public string sceneName;
    public void loadNextScene() {
        SceneManager.LoadScene(sceneName);
    }

    public void exitGame() {
        Debug.Log("Quit Game.");
        Application.Quit();
    }

    public void writeAllDefaultValues() {
       Animator[] anims = GameObject.FindObjectsOfType<Animator>();
       foreach (Animator anim in anims) {
           anim.WriteDefaultValues();
       }
    }

    public void stopBackgroundMusic() {
        AudioManager audioManager = GameManager.FindObjectOfType<AudioManager>();
        if (audioManager != null) {
            audioManager.Stop("ActionTime");
        }
    }
}
