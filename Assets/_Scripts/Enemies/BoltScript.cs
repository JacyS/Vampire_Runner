using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour {

    Rigidbody2D myRigid;

    public float speed;

	// Use this for initialization
	void Start () {
        myRigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        myRigid.velocity = new Vector2(-speed, 0);
	}
}
