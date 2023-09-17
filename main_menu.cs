using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    private static readonly string scoreMapAll = "scoreMapAllPrefs";

    //alive dino pref
    private static readonly string DinoAlivePref = "DinoAlivePref";
    //PlayerPrefs.SetInt(DinoAlivePref, 1);

    public void play_game()
    {
        SceneManager.LoadScene(1);
    }

    public void restart_game()
    {
        PlayerPrefs.SetInt(scoreMapAll, 0);

        // set ZDinoAlive pref to false
        //PlayerPrefs.SetInt(DinoAlivePref, 1);
        SceneManager.LoadScene(1);
    }

    public void home_menu()
    {
        SceneManager.LoadScene(0);
    }

    public void quit_game()
    {
        //Debug.Log(" Quit");
        Application.Quit();
    }
}