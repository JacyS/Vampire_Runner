using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public Button StartButton, OptionsButton, HSButton, OptionsBack, HighscoreBack;
    public GameObject MMenuContain;
    public GameObject OptionsContain;
    public GameObject HighscoreContain;

	// Use this for initialization
	void Start ()
    {
        Button Start = StartButton.GetComponent<Button>();
        Button Options = OptionsButton.GetComponent<Button>();
        Button Highscore = HSButton.GetComponent<Button>();

        MMenuContain.SetActive(true);
        OptionsContain.SetActive(false);
        HighscoreContain.SetActive(false);
        

	}

    public void StartClick()
    {
        MMenuContain.SetActive(false);
        OptionsContain.SetActive(false);
        HighscoreContain.SetActive(false);
    }

    public void OptionsClick()
    {
        MMenuContain.SetActive(false);
        OptionsContain.SetActive(true);
        HighscoreContain.SetActive(false);
    }

    public void HSClick()
    {
        MMenuContain.SetActive(false);
        OptionsContain.SetActive(false);
        HighscoreContain.SetActive(true);
    }

    public void BackClick()
    {
        MMenuContain.SetActive(true);
        OptionsContain.SetActive(false);
        HighscoreContain.SetActive(false);
    }
}
