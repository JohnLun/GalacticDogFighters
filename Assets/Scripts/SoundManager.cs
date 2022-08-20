using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip bulletSound, missileSound, ambientSound, hitSound, destroyedSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        bulletSound = Resources.Load<AudioClip>("bullet");
        missileSound = Resources.Load<AudioClip>("missile");
        ambientSound = Resources.Load<AudioClip>("spaceAmbient");
        hitSound = Resources.Load<AudioClip>("hit");
        destroyedSound = Resources.Load<AudioClip>("destroyed");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PauseSound(string clip)
    {
        switch(clip)
        {
            case "ambient":
                audioSrc.Stop();
                break;
        }
    }

    public static void PlaySound(string clip)
    {
        switch(clip) {
            case "bullet":
                audioSrc.PlayOneShot(bulletSound);
                break;
            case "missile":
                audioSrc.PlayOneShot(missileSound);
                break;
            case "ambient":
                audioSrc.PlayOneShot(ambientSound);
                break;
            case "hit":
                audioSrc.PlayOneShot(hitSound);
                break;
            case "destroy":
                audioSrc.PlayOneShot(destroyedSound);
                break;
        }
    }
}
