using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] clips;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SelectButton() 
    {
        audioSource.PlayOneShot(clips[0]);
    }

    public void SubmitButton() 
    {
        audioSource.PlayOneShot(clips[1]);
    }

    public void NewGameButton()
    { 
        audioSource.PlayOneShot(clips[2]);
    }
}
