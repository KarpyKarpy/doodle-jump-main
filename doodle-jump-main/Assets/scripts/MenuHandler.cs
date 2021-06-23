using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public AudioMixer masterAudio;

    public Slider slider;
    //lets the slider change the volume

    void Start()
    {
        // Sets the slider to the player prefs "Music volume" saved.
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        masterAudio.SetFloat("volume", PlayerPrefs.GetFloat("MusicVolume"));
    }

    public void ChangeVolume(float volume)
    {
        masterAudio.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    //lets the toggle change wether the music is muted or not
    public void ToggleMute(bool isMuted)
    {
        if (isMuted)
        {
            masterAudio.SetFloat("MutedVolume", -80);
            PlayerPrefs.SetFloat("MusicVolume", -80);
        }

        else
        {
            masterAudio.SetFloat("MutedVolume", 0);
            PlayerPrefs.SetFloat("MusicVolume", 0);
        }

    }

    //changes the scene
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    //exits to desktop in build
    //exits play mode in unity
    public void ExitToDesktop()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
