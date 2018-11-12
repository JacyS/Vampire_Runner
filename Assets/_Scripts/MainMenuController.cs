using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

    public Button StartButton, OptionsButton, HSButton, OptionsBack, HighscoreBack, StartBack, PlayButton;
    public GameObject MMenuContain, OptionsContain, HighscoreContain, SkinsContain, PowerUpContain, GameContain;

    // Use this for initialization
    void Start()
    {
        MMenuContain.SetActive(true); //Shows Main Menu as default
        OptionsContain.SetActive(false);
        HighscoreContain.SetActive(false);
        SkinsContain.SetActive(false);
        PowerUpContain.SetActive(false);
        GameContain.SetActive(false);

    }

    public void StartClick()
    {
        MMenuContain.SetActive(false);
        OptionsContain.SetActive(false);
        HighscoreContain.SetActive(false);
        SkinsContain.SetActive(true); //Shows Skins Menu
        PowerUpContain.SetActive(false);
        GameContain.SetActive(false);
    }

    public void OptionsClick()
    {
        MMenuContain.SetActive(false);
        OptionsContain.SetActive(true); //Shows Options Menu
        HighscoreContain.SetActive(false);
        SkinsContain.SetActive(false);
        PowerUpContain.SetActive(false);
        GameContain.SetActive(false);
    }

    public void HSClick()
    {
        MMenuContain.SetActive(false);
        OptionsContain.SetActive(false);
        HighscoreContain.SetActive(true); //Shows Highscore Menu
        SkinsContain.SetActive(false);
        PowerUpContain.SetActive(false);
        GameContain.SetActive(false);
    }

    public void BackClick()
    {
        MMenuContain.SetActive(true); //Shows Main Menu
        OptionsContain.SetActive(false);
        HighscoreContain.SetActive(false);
        SkinsContain.SetActive(false);
        PowerUpContain.SetActive(false);
        GameContain.SetActive(false);
    }

    public void PowersClick()
    {
        MMenuContain.SetActive(false);
        OptionsContain.SetActive(false);
        HighscoreContain.SetActive(false);
        SkinsContain.SetActive(false);
        PowerUpContain.SetActive(true); //Shows Power-up Menu
        GameContain.SetActive(false);
    }

}
