using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Adapted from "Indroduction to AUDIO in Unity" by Brackeys:
 * https://www.youtube.com/watch?v=6OT43pvUyfY
 * As well as the audio manager in first assignment
 *
 * Audio assets from: 
 */

/* Need 'AudioListener' in Main Camera
 * Add 'AudioSource' to the Player 
 */

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixerGroup bgmMixerGroup;

    [SerializeField]
    private AudioMixerGroup sfxMixerGroup;

    [SerializeField]
    private List<Sound> bgmTracks;
    //public Sound[] sounds;

    [SerializeField]
    private List<Sound> sfxClips;

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public static AudioManager instance;
    private Sound trackPlaying;
    private Sound trackFading;
    private Sound sfxPlaying;


    // Use for initialization
    void Awake()
    {
        // if we don't have a audio manager in our scene
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        
        
        /*
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        */

        foreach (var bgm in this.bgmTracks)
        {
            bgm.source = this.gameObject.AddComponent<AudioSource>();
            bgm.source.clip = bgm.clip;
            bgm.source.volume = bgm.volume;
            bgm.source.pitch = bgm.pitch;
            bgm.source.loop = bgm.loop;
            bgm.source.outputAudioMixerGroup = this.bgmMixerGroup;
        }

        foreach (var sfx in this.sfxClips)
        {
            sfx.source = this.gameObject.AddComponent<AudioSource>();
            sfx.source.clip = sfx.clip;
            sfx.source.volume = sfx.volume;
            sfx.source.pitch = sfx.pitch;
            sfx.source.loop = sfx.loop;
            sfx.source.outputAudioMixerGroup = this.sfxMixerGroup;
        }

        // Play initial bgm in main scene
        //this.PlayBgmTrack("BGM1");
    }

    
    private void Start()
    {
        PlayBgmTrack("BGM1");
    }
    

    // When use,
    // FindObjectOfType<AudioManager>().PlayBgmTrack("bgm1");
    // AudioManager.instance.PlayBgmTrack("bgm1");
    // When stop,
    // AudioManager.instance.bgmSource.Stop();
    public void PlayBgmTrack(string name)
    {
        var bgm = this.bgmTracks.Find(bgm => bgm.name == name);

        if (bgm == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        bgm.source.Play();

        if (this.trackPlaying != null)
        {
            this.trackPlaying.source.Stop();
        }

        this.trackPlaying = bgm;
    }

    // When use,
    // FindObjectOfType<AudioManager>().PlaySoundEffects("hit");
    // AudioManager.instance.PlaySoundEffects("bgm1");
    public void PlaySoundEffects(string name)
    {
        var sfx = this.sfxClips.Find(sfx => sfx.name == name);

        if (sfx == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        sfx.source.Play();
    }

    public void StopSoundEffect(string name)
    {
        var sfx = this.sfxClips.Find(sfx => sfx.name == name);

        if (sfx == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        sfx.source.Stop();
    }

    /*

    void Start()
    {
        // insert the bgm asset and name it as 'bgm'
        Play("Spooky_60sSciFi_Loop");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Soound: " + name + " not found");
            return;
        }

        s.source.Play();
    }
    */

    public void ToggleBgm()
    {
        bgmSource.mute = !bgmSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void Bgmvolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

}