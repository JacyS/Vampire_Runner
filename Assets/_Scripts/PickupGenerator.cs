using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGenerator : MonoBehaviour
{
    public GameObject Platform1;
    public GameObject Pickup1;
    public float distanceBetween;
    public float RandomNum;
    public Transform generationPoint;
    float timeToGo;
    private float platformWidth;
    

    void Start()
    {
        platformWidth = Platform1.GetComponent<BoxCollider2D>().size.x;
        timeToGo = Time.fixedTime + 0.75f;
    }

    void FixedUpdate()
    {
        RandomNum = Random.Range(0, 19);
        if (Time.fixedTime >= timeToGo)
        {
            if (RandomNum <= 3 && (transform.position.x < generationPoint.position.x))
            {
                transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

                Instantiate(Pickup1, transform.position, transform.rotation);
            }

            timeToGo = Time.fixedTime + 0.75f;
        }

    }
}
