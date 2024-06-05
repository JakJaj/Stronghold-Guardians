using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip damage;
    public AudioClip ufo_death;
    public AudioClip canon;
    public AudioClip catapult;
    public AudioClip crosbow;
    public AudioClip place_deffence;
    public AudioClip tower_destroy;
    public AudioClip upgrade;
    public AudioClip buying_staff;
    public AudioClip game_over;
    public AudioClip new_wave;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
