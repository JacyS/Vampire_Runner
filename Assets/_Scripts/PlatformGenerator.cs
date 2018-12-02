using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject Platform1;
    public Transform generationPoint;
    public float distanceBetween;
    public float RandomNum;
    float timeToGo;
    public ObjectPooler theObjectPool;
    public ObjectPooler theObjectPool2;
    public ObjectPooler theObjectPool3;
    private PickupGenerator thePickupGenerator;
    private float platformWidth;
    public float randomPickupThreshold;


    // Use this for initialization
    void Start() {
        platformWidth = Platform1.GetComponent<BoxCollider2D>().size.x;
        timeToGo = Time.fixedTime + 0.75f;
        thePickupGenerator = FindObjectOfType<PickupGenerator>();
        randomPickupThreshold = 75f;
    }

    // Update is called once per frame
    void FixedUpdate() {
        RandomNum = Random.Range(0, 19);
        if (Time.fixedTime >= timeToGo)
        {
            if (RandomNum <= 10 && (transform.position.x < generationPoint.position.x))
            {
                transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

                GameObject newPlatform = theObjectPool.GetPooledObject();

                newPlatform.transform.position = transform.position;
                newPlatform.transform.rotation = transform.rotation;
                newPlatform.SetActive(true);

                if (Random.Range(0f, 100f) < randomPickupThreshold)
                {
                    thePickupGenerator.SpawnPickups(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
                }
            }

            else if (RandomNum <= 15 && (transform.position.x < generationPoint.position.x))
            {
                transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

                
                GameObject newPlatform = theObjectPool2.GetPooledObject();

                newPlatform.transform.position = transform.position;
                newPlatform.transform.rotation = transform.rotation;
                newPlatform.SetActive(true);
            }
            else if (RandomNum <= 20 && (transform.position.x < generationPoint.position.x))
            {
                transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
                
                GameObject newPlatform = theObjectPool3.GetPooledObject();

                newPlatform.transform.position = transform.position;
                newPlatform.transform.rotation = transform.rotation;
                newPlatform.SetActive(true);

            }
            timeToGo = Time.fixedTime + 0.75f;


        }

       
    }
   
} 
