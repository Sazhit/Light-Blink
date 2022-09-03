using System;
using UnityEngine;

public class AuidoManager : MonoBehaviour
{
    [SerializeField] private Sound[] _sounds;

    private void Awake()
    {
        foreach (Sound s in _sounds)
        {
             s.source =  gameObject.AddComponent<AudioSource>();
             s.source.clip = s.clip;
             s.source.loop = s.isLoop;
             s.source.playOnAwake = s.playOnAwake;
             s.source.volume = s.volume;
        }
    }

    public void PlayClipByName(string _clipName)
    {
       Sound soundToPlay = Array.Find(_sounds, dummySound => dummySound.clipName == _clipName);
       soundToPlay.source.Play();
    }
}
