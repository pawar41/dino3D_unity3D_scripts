using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_manager : MonoBehaviour
{

    private static readonly string musicPrefs = "musicPrefs";
    private static readonly string soundPrefs = "soundPrefs";

    // audio sources
    public AudioSource[] music_audio_sources;
    public AudioSource[] sound_effect_audio_sources;

    // value storing float
    private float sound_effects_float, music_effects_float;

    void Awake()
    {
        continue_settings();
    }

    public void continue_settings()
    {
        // get back saved music setting
        sound_effects_float = PlayerPrefs.GetFloat(soundPrefs);
        music_effects_float = PlayerPrefs.GetFloat(musicPrefs);

        for (int i = 0; i < music_audio_sources.Length; i++)
        {
            music_audio_sources[i].volume = music_effects_float;
        }

        for (int i = 0; i < sound_effect_audio_sources.Length; i++)
        {
            sound_effect_audio_sources[i].volume = sound_effects_float;
        }
    }

    
}
