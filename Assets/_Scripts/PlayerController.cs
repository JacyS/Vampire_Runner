using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;


    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)) //add mobile input here for mobile testing later. (||) use those to define OR later, your stupid keyboard doesnt have them. 
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }
	}

    public void GetPowerup()
    {
        Debug.Log("Powerup Collected!!!");
    }
}
