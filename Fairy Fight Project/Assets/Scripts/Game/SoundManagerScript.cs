using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerScript : MonoBehaviour
{
    private float mVolume = 1f;
    public Slider mSlider;

    public static AudioClip damageTakeSound, gameMusicSound;

    public static AudioSource audioSrc;

    void Start()
    {
        damageTakeSound = Resources.Load<AudioClip>("Music/Character/Damage_take_sound");
        gameMusicSound= Resources.Load<AudioClip>("Music/Game/Game_theme");
        audioSrc = GetComponent<AudioSource>();
        audioSrc.PlayOneShot(gameMusicSound);
        mVolume = PlayerPrefs.GetFloat("volume");
        audioSrc.volume = mVolume;
        mSlider.value = mVolume;
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = mVolume;
        PlayerPrefs.SetFloat("volume", mVolume);
    }

    public void updateVolume(float volume)
    {
        mVolume = volume;
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
