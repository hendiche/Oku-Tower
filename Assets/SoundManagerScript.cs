using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static AudioClip poofSound, tanukiSound, daijoubuSound, countdownSound,
    badpoofSound, hoverSound, pressSound, pointSound;

    static AudioSource audioSrc;

    void Start()
    {
        poofSound = Resources.Load<AudioClip>("poof");
        badpoofSound = Resources.Load<AudioClip>("badpoof");
        tanukiSound = Resources.Load<AudioClip>("tanuki");
        pointSound = Resources.Load<AudioClip>("point");
        countdownSound = Resources.Load<AudioClip>("countdown");
        daijoubuSound = Resources.Load<AudioClip>("daijoubu");
        hoverSound = Resources.Load<AudioClip>("hover");
        pressSound = Resources.Load<AudioClip>("press");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip) {
        switch(clip) {
            case("poof") :
                audioSrc.PlayOneShot(poofSound);
                break;

            case("badpoof") :
                audioSrc.PlayOneShot(poofSound);
                break;
                
            case("tanuki") :
                audioSrc.PlayOneShot(tanukiSound);
                break;
                
            case("point") :
                audioSrc.PlayOneShot(pointSound);
                break;
                
            case("daijoubu") :
                audioSrc.PlayOneShot(daijoubuSound);
                break;
                
            case("countdown") :
                audioSrc.PlayOneShot(countdownSound);
                break;
                
            case("hover") :
                audioSrc.PlayOneShot(hoverSound);
                break;
                
            case("press") :
                audioSrc.PlayOneShot(pressSound);
                break;
        }
    }
}
