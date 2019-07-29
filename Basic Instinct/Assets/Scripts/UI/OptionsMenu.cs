using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class OptionsMenu : MonoBehaviour {
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public TMP_Dropdown qualityDropdown;
    public Slider volumeSlider;
    private List<Resolution> resolutions;

    void Start() {
        // Initialise
        resolutions = new List<Resolution>();
        // Set dropdown options to the available resolutions for each user
        // and set default resolution to default resolution of system
        resolutionDropdown.ClearOptions();
        // Get user's screen's refresh rate
        int screenRefreshRate = Screen.currentResolution.refreshRate;
        List<string> options = new List<string>();
        // Filter user's refresh rate resolutions only
        foreach (Resolution res in Screen.resolutions) {
            if (res.refreshRate == screenRefreshRate) {
                resolutions.Add(res);
            }
        }
        int defaultIndex = 0;
        for (int i = 0; i < resolutions.Count; i++) {
            Resolution res = resolutions[i];
            options.Add(res.width + " X " + res.height);
            if (res.width == PlayerPrefs.GetInt("ResolutionWidth", Screen.currentResolution.width) && 
                res.height == PlayerPrefs.GetInt("ResolutionHeight", Screen.currentResolution.height)) {
                defaultIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = defaultIndex;
        resolutionDropdown.RefreshShownValue();

        // Set visuals to match settings
        
        // Fullscreen
        bool fullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1 ? true : false;
        fullscreenToggle.isOn = fullscreen;

        // Quality
        int qualityIndex = PlayerPrefs.GetInt("Quality", 0);
        qualityDropdown.value = qualityIndex;

        // Volume
        float volume = PlayerPrefs.GetFloat("Volume", 0);
        volumeSlider.value = volume;
    }

    public void setResolution(int resolutionIndex) {
        Resolution chosenResolution = resolutions[resolutionIndex];
        Screen.SetResolution(chosenResolution.width, chosenResolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionWidth", chosenResolution.width);
        PlayerPrefs.SetInt("ResolutionHeight", chosenResolution.height);
    }

    public void setFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
    }

    public void setQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("Quality", qualityIndex);
    }

    public void setVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void writeAllDefaultValues() {
       Animator[] anims = GameObject.FindObjectsOfType<Animator>();
       foreach (Animator anim in anims) {
           anim.WriteDefaultValues();
       }
    }
}
