using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider DifficultySlider;
    [SerializeField] private float defaultValue = 0.8f;
    
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        DifficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    public void SetDefault()
    {
        volumeSlider.value = defaultValue;
        DifficultySlider.value = Mathf.Round(defaultValue);
    }

    public void SaveAndLeave()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty((int)DifficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }
    
    void Update()
    {
        var myMusicPlayer = FindObjectOfType<MusicPlayer>();
        if (myMusicPlayer)
        {
            myMusicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("Music player is not initialized");
        }
    }
}
