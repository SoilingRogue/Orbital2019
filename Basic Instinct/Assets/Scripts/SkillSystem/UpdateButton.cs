using UnityEngine;
using UnityEngine.UI;

public class UpdateButton : MonoBehaviour {
    public Text Text;
    public GameObject panel;
    public float panelBaseAlpha;

    public void updateText(string hotkey) {
        Text.text = hotkey;
    }

    public void updatePanel(float cd) {
        Image img = panel.GetComponent<Image>();
        img.color = new Color(img.color.r, img.color.g, img.color.b, panelBaseAlpha * (1 - cd));
    }
}
