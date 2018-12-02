using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject Platform1;
    public Transform generationPoint;
    public float distanceBetween;
    public float RandomNum;
    float timeToGo;

    private float platformWidth;


    // Use this for initialization
    void Start() {
        platformWidth = Platform1.GetComponent<BoxCollider2D>().size.x;
        timeToGo = Time.fixedTime + 1.0f;

    }

    // Update is called once per frame
    void FixedUpdate() {
        RandomNum = Random.Range(1, 20);
        if (Time.fixedTime >= timeToGo)
        {
            if (RandomNum <= 10 && (transform.position.x < generationPoint.position.x))
            {
                transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

                Instantiate(Platform1, transform.position, transform.rotation);
            }
            timeToGo = Time.fixedTime + 1.0f;


        }

       
    }
   
} 
