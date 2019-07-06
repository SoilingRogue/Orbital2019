using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class OptionsMenu : MonoBehaviour {
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    void Start() {
        // Set dropdown options to the available resolutions for each user
        // and set default resolution to default resolution of system
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int defaultIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            Resolution res = resolutions[i];
            options.Add(res.width + " X " + res.height);
            if (res.Equals(Screen.currentResolution)) {
                defaultIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = defaultIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void setResolution(int resolutionIndex) {
        Resolution chosenResolution = resolutions[resolutionIndex];
        Screen.SetResolution(chosenResolution.width, chosenResolution.height, Screen.fullScreen);
    }

    public void setFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

    public void setQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
    }
}
