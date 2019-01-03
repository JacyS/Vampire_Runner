using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class CLICK_MENU : MonoBehaviour {

    public AudioClip click_Sound;

    //GameObject myaudiosource;

    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source;

    // Use this for initialization
    void Start () {
        source = GameObject.Find("SFXobj").GetComponent<AudioSource>();
	}

    void PlaySound()
    {
        source.PlayOneShot(click_Sound);
    }
}
