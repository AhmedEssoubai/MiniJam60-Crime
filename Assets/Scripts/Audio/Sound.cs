using UnityEngine;

[System.Serializable]
/// <summary>
/// A sound in the game
/// </summary>
public class Sound
{
    #region Public properties

    /// <summary>
    /// The name of the sound
    /// </summary>
    public string Name;

    /// <summary>
    /// The audio clip of the sound
    /// </summary>
    public AudioClip Clip;

    /// <summary>
    /// The volume of the sound
    /// </summary>
    [Range(0f, 1f)]
    public float Volume = 1;

    /// <summary>
    /// The pitch of the sound
    /// </summary>
    [Range(.1f, 1f)]
    public float Pitch = 1;

    /// <summary>
    /// Is a loop sound
    /// </summary>
    public bool Loop;

    /// <summary>
    /// Is the sound a backgound music or sound effect
    /// </summary>
    public bool IsMusic;

    /// <summary>
    /// The audio source of the sound
    /// [NOTE : Not a serialize field]
    /// </summary>
    [HideInInspector]
    public AudioSource source;

    #endregion

    #region Sets

    /// <summary>
    /// Set the volume of the sound
    /// </summary>
    /// <param name="value">The value of volume</param>
    public void SetVolume(float value)
    {
        source.volume = value;
    }

    /// <summary>
    /// Mute or unmute the sound
    /// </summary>
    /// <param name="value">Mute / Unmute</param>
    public void SetMute(bool value)
    {
        source.mute = value;
    }

    #endregion
}
