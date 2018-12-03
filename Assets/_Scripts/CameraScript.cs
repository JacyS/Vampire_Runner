using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    GameObject Player;

    float inFrontAmount = 2;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;

        pos.x = Player.transform.position.x + inFrontAmount;

        transform.position = pos;
	}
}
