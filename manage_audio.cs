 
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class manage_audio : MonoBehaviour
{
    private static readonly string first_play = "FirstPlay";
    private static readonly string musicPrefs = "musicPrefs";
    private static readonly string soundPrefs = "soundPrefs";

    // high score prefs
    private static readonly string highScorePrefs = "highScorePrefs";

    // scoreMap score prefs
    private static readonly string scoreMapAll = "scoreMapAllPrefs";

    // global acceration
    // global prevMap
    private static readonly string prevMapPref = "prevMapPref";
    private static readonly string accelerationPref = "accelerationPref";

    //dinosour alive pref
    private static readonly string DinoAlivePref = "DinoAlivePref";


    private int first_play_status;

    //range [0, 1]
    public Slider sound_effects_slider, music_effects_slider;
    private float sound_effects_float, music_effects_float;

    // audio sources
    public AudioSource[] music_audio_sources;
    public AudioSource[] sound_effect_audio_sources;

    // score text
    public TextMeshProUGUI highScore;

    public AudioSource buttonClick;

 

    void Start()
    {
        first_play_status = PlayerPrefs.GetInt(first_play);
        PlayerPrefs.SetInt(scoreMapAll,100);

        // set prevMapPref
        PlayerPrefs.SetInt(prevMapPref, 0);

        // set speed
        PlayerPrefs.SetFloat(accelerationPref, 30f);

        // make dino Alive
        PlayerPrefs.SetInt(DinoAlivePref, 1);



        if (first_play_status == 0)
        {
            // default slider value
            sound_effects_float = 1f;
            music_effects_float = 0.3f;

            // assign to slider
            sound_effects_slider.value = sound_effects_float;
            music_effects_slider.value = music_effects_float;

            // save pref across scene
            PlayerPrefs.SetFloat(musicPrefs, music_effects_float);
            PlayerPrefs.SetFloat(soundPrefs, sound_effects_float);

            // update first time pref
            PlayerPrefs.SetInt(first_play, -1);


            // high-score pref save
            PlayerPrefs.SetInt(highScorePrefs, 0);

        }
        else
        {
            // get back saved music setting
            sound_effects_float = PlayerPrefs.GetFloat(soundPrefs, sound_effects_float);
            music_effects_float = PlayerPrefs.GetFloat(musicPrefs, music_effects_float);

            // set that slider value
            sound_effects_slider.value = sound_effects_float;
            music_effects_slider.value = music_effects_float;

            // get and set highscore
            highScore.SetText(PlayerPrefs.GetInt(highScorePrefs).ToString());
            update_sound();
        }

        //  Example of change text of component
        //      highScore.SetText("hello");
    }

    public void save_sound_setting()
    {
        // save pref across scene
        PlayerPrefs.SetFloat(musicPrefs, music_effects_slider.value);
        PlayerPrefs.SetFloat(soundPrefs, sound_effects_slider.value);

        PlayerPrefs.Save();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            save_sound_setting();
        }
    }

    public void update_sound()
    {
        for(int i = 0; i < music_audio_sources.Length; i++)
        {
            music_audio_sources[i].volume = music_effects_slider.value;
        }

        for (int i = 0; i < sound_effect_audio_sources.Length; i++)
        {
            sound_effect_audio_sources[i].volume = sound_effects_slider.value;
        }

        buttonClick.volume = sound_effects_slider.value;
    }

    public void clickSounds()
    {
        buttonClick.Play();
    }
}
    

