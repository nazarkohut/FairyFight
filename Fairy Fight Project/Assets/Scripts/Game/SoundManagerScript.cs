using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip damageTakeSound, gameMusicSound;
    static AudioSource audioSrc;
    void Start()
    {
        damageTakeSound = Resources.Load<AudioClip>("Music/Character/Damage_take_sound");
        gameMusicSound= Resources.Load<AudioClip>("Music/Game/Game_theme");
        audioSrc = GetComponent<AudioSource>();
        audioSrc.PlayOneShot(gameMusicSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "damage_take":
                audioSrc.PlayOneShot(damageTakeSound);
                break;
        }
    }
}
