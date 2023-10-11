using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    [SerializeField] private AudioClip onDeathSfx, attackSfx;
    [SerializeField] private float volume = 1f;


    //reference
    private AudioSource myAudioSource;

    public void PlayOnDeathSfx()
    {
        myAudioSource.PlayOneShot(onDeathSfx, volume);
    }

    public void PlayAttackSfx()
    {
        myAudioSource.PlayOneShot(attackSfx, volume);   
    }

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
}
