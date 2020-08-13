using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    /*#region Static Properties

    /// <summary>
    /// Static instance of the class
    /// </summary>
    private static AudioManager _instance;

    #endregion*/

    #region Public static properties

    /// <summary>
    /// Static instance of the audio manager
    /// </summary>
    public static AudioManager Instance
    {
        private set;/* { _instance = value; }*/
        get;/* { return _instance; }*/
    }

    #endregion

    #region Public properties

    /// <summary>
    /// The managed sounds
    /// </summary>
    public Sound[] Sounds;

    /// <summary>
    /// Is the sound fx mute or not
    /// </summary>
    public bool IsSoundFXMute;

    /// <summary>
    /// Is the music mute or not
    /// </summary>
    public bool IsMusicMute;

    /// <summary>
    /// The audio mixer group of theme music
    /// </summary>
    public AudioMixerGroup ThemeMixerGroup;

    #endregion

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        Play("Theme");
    }

    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        // Destory if already exists
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        // Don't destroy manager between scences
        DontDestroyOnLoad(gameObject);

        // Create sounds
        foreach (Sound s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;
            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.loop = s.Loop;
            s.source.mute = s.IsMusic ? IsMusicMute : IsSoundFXMute;
            if (s.Name == "Theme")
                s.source.outputAudioMixerGroup = ThemeMixerGroup;
        }
    }

    /*#region Test
    private float t = 0;

    private void Update()
    {
        t += Time.deltaTime;
        if (t / 3 > 1)
        {
            t = 0;
            var sound = Array.Find(Sounds, s => s.Name == "Theme");
            if (sound.source.pitch == 1.5f)
                return;
            sound.source.pitch += 0.1f;
            ThemeMixerGroup.audioMixer.SetFloat("pitchBend", 1f / sound.source.pitch);
        }
    }

    #endregion*/

    /// <summary>
    /// Play a sound
    /// </summary>
    public void Play(string name)
    {
        var sound = Array.Find(Sounds, s => s.Name == name);

        if (sound == null)
            Debug.Log("Sound not found");
        else
            sound.source.Play();
    }

    /// <summary>
    /// Mute or unmute all the sounds
    /// </summary>
    /// <param name="value">Mute / Unmute</param>
    /// <param name="forAll">Mute / Unmute all sounds</param>
    /// <param name="forMusic">Mute / Unmute music sounds or sound effects</param>
    public void SetMute(bool value, bool forAll = true, bool forMusic = false)
    {
        if (forAll || forMusic)
            IsMusicMute = value;
        if (forAll || !forMusic)
            IsSoundFXMute = value;
        foreach (Sound sound in Sounds)
            sound.SetMute(sound.IsMusic ? IsMusicMute : IsSoundFXMute);
    }
}
