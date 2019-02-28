using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static AudioClip poofSound,

    tanukiSound,

    pointSound;

    static AudioSource audioSrc;

    void Start()
    {
        poofSound = Resources.Load<AudioClip>("poof");
        tanukiSound = Resources.Load<AudioClip>("tanuki");
        pointSound = Resources.Load<AudioClip>("point");

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
        }
    }
}
