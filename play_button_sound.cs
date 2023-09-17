using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_button_sound : MonoBehaviour
{
    private static readonly string soundPrefs = "soundPrefs";


    public AudioSource buttonSound;


    // Start is called before the first frame update
    void Awake()
    {
        buttonSound.volume = PlayerPrefs.GetFloat(soundPrefs);
    }

    public void clickSound()
    {
        buttonSound.Play();
    }
}
