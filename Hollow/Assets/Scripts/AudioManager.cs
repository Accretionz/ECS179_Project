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
        else
        {
            bgmSource.clip = bgm.clip;
            bgmSource.Play();
        }
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
        else
        {
            sfxSource.clip = sfx.clip;
            sfxSource.Play();
        }
    }

    public void StopSoundEffect(string name)
    {
        var sfx = this.sfxClips.Find(sfx => sfx.name == name);

        if (sfx == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        sfxSource.Stop();
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