using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static AudioClip poofSound,

    tanukiSound,

    daijoubuSound,

    pointSound;

    static AudioSource audioSrc;

    void Start()
    {
        poofSound = Resources.Load<AudioClip>("poof");
        tanukiSound = Resources.Load<AudioClip>("tanuki");
        pointSound = Resources.Load<AudioClip>("point");
        daijoubuSound = Resources.Load<AudioClip>("Daijoubu");

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
                
            case("tanuki") :
                audioSrc.PlayOneShot(tanukiSound);
                break;
                
            case("point") :
                audioSrc.PlayOneShot(pointSound);
                break;
                
            case("daijoubu") :
                audioSrc.PlayOneShot(daijoubuSound);
                break;
        }
    }
}
