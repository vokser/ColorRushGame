using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sprite soundOnIcon;
    [SerializeField] private Sprite soundOffIcon;
    [SerializeField] private Image soundToggleButtonIcon;
    [SerializeField] private Sprite musicOnIcon;
    [SerializeField] private Sprite musicOffIcon;
    [SerializeField] private Image musicToggleButtonIcon;
    [SerializeField] private AudioSource tapSound;
    [SerializeField] private AudioSource backgroundMusic;

    private bool isSoundEnabled = true;
    private bool isMusicEnabled = true;
   

    private void Awake()
    {
        LoadSoundSettings();
        LoadMusicSettings();
    }

    private void SaveSoundSettings()
    {
        PlayerPrefs.SetInt("SoundEnabled", isSoundEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void SaveMusicSettings()
    {
        PlayerPrefs.SetInt("MusicEnabled", isMusicEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void UpdateSoundIcon()
    {
        if(soundToggleButtonIcon != null)
            soundToggleButtonIcon.sprite = isSoundEnabled ? soundOnIcon : soundOffIcon;
    }

    private void UpdateMusicIcon()
    {
        if(musicToggleButtonIcon != null)
            musicToggleButtonIcon.sprite = isMusicEnabled ? musicOnIcon : musicOffIcon;
    }
    
    private void LoadSoundSettings()
    {
        isSoundEnabled = PlayerPrefs.GetInt("SoundEnabled", 1) == 1;       
        float volume = isSoundEnabled ? 1 : 0;
        tapSound.volume = volume;
        UpdateSoundIcon();

    }
    
    private void LoadMusicSettings()
    {
        isMusicEnabled = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        float volume = isMusicEnabled ? 1 : 0;
        backgroundMusic.volume = volume;
        UpdateMusicIcon();
    }

    private void PlayButtonSound()
    {
        if(tapSound != null && tapSound.isActiveAndEnabled)
        {
            tapSound.Play();
        }
    }

    private void ToggleSound()
    {
        isSoundEnabled = !isSoundEnabled;
        float volume = isSoundEnabled ? 1 : 0;
        tapSound.volume = volume;
        SaveSoundSettings();
        UpdateSoundIcon();
    }

    private void ToggleMusic()
    {
        isMusicEnabled= !isMusicEnabled;
        float volume = isMusicEnabled ? 1 : 0;
        backgroundMusic.volume = volume;
        SaveMusicSettings();
        UpdateMusicIcon();
    }
    
}
