using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------ Audio Source ------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------ Audio Clip ------")]
    public AudioClip death;
    public AudioClip shootCatchBall;
    public AudioClip damagePlayer;
    public AudioClip jumpingChar;
    public AudioClip captureMonster;

    //FOR TESTING SOUND IN GAME
    // private void Start()
    // {
    //     musicSource.clip = death;
    //     musicSource.Play();
    // }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
