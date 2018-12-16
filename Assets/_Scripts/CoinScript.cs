using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    bool magnet = false;

    float speed = 10;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (magnet)
        {

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position,speed *Time.deltaTime);
        }
	}

    public void Magnet()
    {
        magnet = true;
    }
}
