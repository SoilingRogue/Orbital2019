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
}
