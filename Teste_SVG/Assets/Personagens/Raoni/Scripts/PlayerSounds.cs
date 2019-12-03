using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] gramaClips;
    [SerializeField]
    private AudioClip[] gramaForteClips;
    [SerializeField]
    private AudioClip[] terraClips;
    [SerializeField]
    private AudioClip[] madeiraClips;
    [SerializeField]
    private AudioClip[] pedraClips;
    [SerializeField]
    private AudioClip[] umidoClips;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        if(SoundTracing.material == 0)
        {
            return gramaClips[UnityEngine.Random.Range(0,gramaClips.Length)];
        }
        else if(SoundTracing.material == 1)
        {
            return gramaForteClips[UnityEngine.Random.Range(0,gramaForteClips.Length)];
        }
        else if(SoundTracing.material == 2)
        {
            return terraClips[UnityEngine.Random.Range(0,terraClips.Length)];
        }
        else if(SoundTracing.material == 3)
        {
            return madeiraClips[UnityEngine.Random.Range(0,madeiraClips.Length)];
        }
        else if(SoundTracing.material == 4)
        {
            return pedraClips[UnityEngine.Random.Range(0,pedraClips.Length)];
        }
        else if(SoundTracing.material == 5)
        {
            return umidoClips[UnityEngine.Random.Range(0,umidoClips.Length)];
        }
        else
        {
            return null;
        }
    }
}
