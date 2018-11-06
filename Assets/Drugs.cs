using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drugs : MonoBehaviour {

    public float Sobriety = 0;
    public float crack = 1;
    public float highness = 0;

	// Use this for initialization
	void Start () {

        if (Sobriety == 0)
        {
            highness = Sobriety + crack;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
