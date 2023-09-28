using System;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Sound[] _sounds;

    private bool _isMuted;

    public bool IsMuted => _isMuted;

    public static AudioController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (var sound in _sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();

            sound.Source.clip = sound.Clip;
            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
        }

        Play(Constants.StaticVariables.ThemeSound);
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(_sounds, sound => sound.Name == name);

        if (sound != null)
            sound.Source.Play();
        else
            throw new Exception();
    }

    public void Stop(string name)
    {
        Sound sound = Array.Find(_sounds, sound => sound.Name == name);

        if (sound != null)
            sound.Source.Stop();
        else
            throw new Exception();
    }

    public void ChangeVolume(float value)
    {
        foreach(var sound in _sounds)
        {
            sound.Source.volume = value;
            PlayerPrefs.SetFloat(Constants.PlayerPrefsConstants.Volume, sound.Volume);
        }
    }

    public void Mute()
    {
        foreach(var sound in _sounds)
        {
            sound.Source.volume = 0;
        }

        _isMuted = true;
    }

    public void Unmute()
    {
        float value = PlayerPrefs.GetFloat(Constants.PlayerPrefsConstants.Volume);

        foreach (var sound in _sounds)
        {
            if (value > 1)
                sound.Source.volume = value;
            else
                sound.Source.volume = 100;
        }

        _isMuted = false;
    }
}