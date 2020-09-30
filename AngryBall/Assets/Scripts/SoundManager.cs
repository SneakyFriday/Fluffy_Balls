using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerThrowSound;
    static AudioSource audioSrc;
    void Start()
    {
        playerThrowSound = Resources.Load<AudioClip>("playerThrow");

        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = 0.3f;
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "playerThrow":
                audioSrc.PlayOneShot(playerThrowSound);
                break;
        }
    }
}
