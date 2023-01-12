using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [Header("BGM")] 
    public AudioSource bgmSource;
    public Sound[] bgmSound;

    [Header("SFX")] 
    public AudioSource sfxSource;
    public Sound[] sfxSound;

    private void Awake()
    {
        if(instance != null && instance != this) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void PlayBGM(string name)
    {
        Sound s = Array.Find(bgmSound, s => s.name == name);

        if (s == null)
        {
            Debug.LogWarning("BGM Missing");
            return;
        }
        
        bgmSource.clip = s.clip;
        bgmSource.volume = s.volume;
        bgmSource.pitch = s.pitch;
        bgmSource.loop = s.loop;
        
        bgmSource.Play();
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSound, x => x.name == name);

        if (s == null)
        {
            Debug.LogWarning("SFX Missing");
            return;
        }
        
        sfxSource.clip = s.clip;
        sfxSource.volume = s.volume;
        
        sfxSource.PlayOneShot(sfxSource.clip);
    }
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume;
    [Range(0.3f, 3f)] public float pitch;
    public bool loop;
}