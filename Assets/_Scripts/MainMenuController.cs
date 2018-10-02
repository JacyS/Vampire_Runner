using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public GameObject StartButton;
    public GameObject OptionsButton;
    public GameObject HighscoreButton;
    public GameObject OptionsBack;
    public GameObject HighscoreBack;
    public GameObject MMenuContain;
    public GameObject OptionsContain;
    public GameObject HighscoreContain;

	// Use this for initialization
	void Start ()
    {
        OptionsContain.gameObject.SetActive = false;

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
