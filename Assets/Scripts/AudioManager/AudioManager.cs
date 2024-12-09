using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sound;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Sounds s in sound)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
        PlaySound("MainMenu");
    }

    public void PlaySound(string name)
    {
        foreach(Sounds s in sound)
        {
            if(s.name == name)
            s.source.Play();
        }
    }

}
