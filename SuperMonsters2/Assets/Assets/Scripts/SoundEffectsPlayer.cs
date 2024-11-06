using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3;
    //Sound for player
    public void Player1()
    {
        src.clip =sfx1;
        src.Play();
    }
    //Sound for Monster 1
    public void Monster1()
    {
        src.clip =sfx2;
        src.Play();
    }
    //Sound for Monster 2
    public void Monster2()
    {
        src.clip =sfx3;
        src.Play();
    }
}
