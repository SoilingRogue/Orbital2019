using UnityEngine;
using UnityEngine.UI;

public class UpdateButton : MonoBehaviour {
    public Text Text;
    public GameObject panel;
    private Image panelImage;
    public float panelBaseAlpha;
    public Skill trackedSkill;
    public KeyCode displayedKey;

    void Start() {
        panelImage = panel.GetComponent<Image>();
    }

    void LateUpdate() {
        Text.text = displayedKey.ToString();
        float cd = trackedSkill.getPercentageCD();
        Color transparent = new Color(0, 0, 0, 0);
        panelImage.color = Color.Lerp(transparent, Color.black, cd);
    }
}
