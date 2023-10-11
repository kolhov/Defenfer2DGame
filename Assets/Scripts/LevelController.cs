using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Object = System.Object;

public class LevelController : MonoBehaviour
{
    //fields
    [SerializeField] private GameObject winLabel;
    [SerializeField] private GameObject loseLabel;
    
    [Tooltip("wait before load next level in seconds")]
    [SerializeField] private float waitToLoad = 1.8f;
    
    //State
    private int numberOfAttackers = 0;
    private bool isLevelTimerFinished = false;
    private Object block = new Object();
    
    //References
    private AudioSource myAudioSource;
    
    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        
        Debug.Log("Difficulty level " + PlayerPrefsController.GetDifficulty());
    }

    public void AttackerSpawned()
    {
        ++numberOfAttackers;
    }

    public void AttackerKilled()
    {
        --numberOfAttackers;
        if (numberOfAttackers == 0 && isLevelTimerFinished)
        {
            lock (block)
            {
                StartCoroutine(CorLevelComplete());
            }
        }
    }

    IEnumerator CorLevelComplete()
    {
        winLabel.SetActive(true);
        PlayWinAudioClip();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    private void PlayWinAudioClip()
    {
        myAudioSource.volume = PlayerPrefsController.GetMasterVolume();
        myAudioSource.Play();
    }

    public void LevelLose()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void LevelTimerFinished()
    {
        isLevelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        var spawnerArr = FindObjectsOfType<AttackerSpawner>();
        foreach (var spawner in spawnerArr)
        {
            spawner.StopSpawning();
        }
        
    }
}
