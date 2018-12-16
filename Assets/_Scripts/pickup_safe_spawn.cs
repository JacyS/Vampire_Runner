using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_safe_spawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hazard")
        {
            Vector2 pos = transform.position;
            pos.y += 1;
            transform.position = pos;
        }

        if (collision.tag == "powerup")//if you are a coin and inside a powerup then delete self
        {
            Debug.Log("collide with powerup");
            this.gameObject.SetActive(false);
        }
    }
}
