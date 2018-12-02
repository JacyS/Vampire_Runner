using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfScript : MonoBehaviour {

    public GameObject CrossbowBolt;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MyTrigger()
    {
        Instantiate(CrossbowBolt, transform.position, Quaternion.identity);
    }
}
