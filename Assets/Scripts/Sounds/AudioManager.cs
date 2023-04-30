using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; set; }
    public List<Sound> sounds;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume= sound.volume;
            sound.source.pitch= sound.pitch;
            sound.source.loop = sound.loop;
        }
    }
    private void Start()
    {
        Play("Theme");
    }
    public void Play(string name)
    {
        Sound sound = sounds.Find(sound => sound.name == name);
        sound.source?.Play();
    }
    public void Pause(string name)
    {
        Sound sound = sounds.Find(sound => sound.name == name);
        sound.source?.Pause();
    }
    public void Stop(string name)
    {
        Sound sound = sounds.Find(sound => sound.name == name);
        sound.source?.Stop();
    }
    public bool IsPlaying(string name)
    {
        Sound sound = sounds.Find(sound => sound.name == name);
        return sound.source.isPlaying;
    }
}
