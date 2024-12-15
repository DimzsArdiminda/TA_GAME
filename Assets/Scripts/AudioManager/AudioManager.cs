using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [Header("----------- Audio Sources -------------")]
   [SerializeField] AudioSource musicSource;
   [SerializeField] AudioSource SFXSource;

   [Header("----------- Background Music -------------")]
   public AudioClip background;

   [Header("----------- Sound Effects -------------")]
   public AudioClip buttonClick;
   public AudioClip newRun;
   public AudioClip gameOver;
   public AudioClip healthPoint;
   public AudioClip missionComplete;

   public void Start()
   {
       Debug.Log("Starting background music...");
       musicSource.clip = background;
       musicSource.Play();
   }

   public void PlaySFX(AudioClip clip)
   {
        // SFXSource.PlayOneShot(clip);
        if (SFXSource != null && clip != null)
        {
            SFXSource.PlayOneShot(clip);
        }
    //    Debug.Log("Playing sound effect: " + clip.name);
    //    SFXSource.clip = clip;
    //    SFXSource.Play();
   }
}
