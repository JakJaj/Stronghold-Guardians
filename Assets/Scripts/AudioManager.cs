using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource enemyHit;
    [SerializeField] AudioSource ufoDeath;
    [SerializeField] AudioSource placeDefence;
    [SerializeField] AudioSource gameOver;

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

    public void PlayEnemyHit(AudioClip clip)
    {
        enemyHit.PlayOneShot(clip);
    }

    public void PlayUfoDeath(AudioClip clip)
    {
        ufoDeath.PlayOneShot(clip);
    }

    public void PlayPlaceDefence(AudioClip clip)
    {
        placeDefence.PlayOneShot(clip);
    }

    public void PlayGameOver(AudioClip clip)
    {
        gameOver.PlayOneShot(clip);
    }

    public void StopAllAudio()
    {
        musicSource.Stop();
        enemyHit.Stop();
        ufoDeath.Stop();
        placeDefence.Stop();
    }
}
