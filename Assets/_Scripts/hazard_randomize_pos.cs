using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazard_randomize_pos : MonoBehaviour {

    public float x_amount;
    public float y_amount;

    public bool delete_me;

    // Use this for initialization
    void Start () {
        //give the object a 50% chance of moving to the place it can move to
        if (Random.Range(0, 100) > 50)
        {
            Vector2 pos = transform.position;
            pos.x += x_amount;
            pos.y += y_amount;
            transform.position = pos;
        }


        if (delete_me)//if delete is true give 75% chance to delete itself
        {
            if (Random.Range(0, 100) >25)
            {
                this.gameObject.SetActive(false);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
