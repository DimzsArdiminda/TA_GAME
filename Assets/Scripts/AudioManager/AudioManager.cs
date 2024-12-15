using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------- Audio Sources -------------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("----------- Background Music -------------")]
    public AudioClip background;

    [Header("----------- Sound Effects -------------")]
    public List<AudioClip> soundEffects; // Koleksi efek suara

    public void Start()
    {
        // Mulai musik latar
        musicSource.clip = background;
        musicSource.Play();
    }

    // Mainkan semua suara dalam daftar `audioSources`
    public List<AudioSource> audioSources;

    private void PlayAllSounds()
    {
        foreach (var source in audioSources)
        {
            source.Play();
        }
    }

    // Mainkan efek suara berdasarkan AudioClip
    public void PlaySFX(AudioClip clip)
    {
        if (SFXSource != null && clip != null)
        {
            SFXSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("SFXSource or clip is null.");
        }
    }

    // Mainkan efek suara berdasarkan nama
    public void PlaySFXByName(string soundName)
    {
        AudioClip clip = GetSoundClipByName(soundName); // Cari klip berdasarkan nama
        if (clip != null)
        {
            PlaySFX(clip);
        }
        else
        {
            Debug.LogWarning($"Sound: {soundName} not found!");
        }
    }

    // Cari AudioClip berdasarkan nama
    private AudioClip GetSoundClipByName(string soundName)
    {
        foreach (AudioClip clip in soundEffects)
        {
            if (clip.name == soundName) // Bandingkan nama klip
            {
                return clip;
            }
        }
        return null;
    }
}
