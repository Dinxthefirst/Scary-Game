using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider sensitivitySlider;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;


    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
    public void VolumeSlider()
    {
        Debug.Log("Volume: " + volumeSlider.value);
        StateNameController.volume = volumeSlider.value;
    }

    public void SensitivitySlider()
    {
        Debug.Log("Sensitivity: " + sensitivitySlider.value);
        StateNameController.mouseSensitivity = sensitivitySlider.value;
    }

    public void UpdateSliders() 
    {
        volumeSlider.value = StateNameController.volume;
        sensitivitySlider.value = StateNameController.mouseSensitivity;
    }

    public void SetVolume(float volume)
    {
        //audioMixer.SetFloat("volume", value);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex, true);
    }
}
