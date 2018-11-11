using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;


	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)) //add mobile input here for mobile testing later. (||) use those to define OR later, your stupid keyboard doesnt have them. 
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        }
	}
}
