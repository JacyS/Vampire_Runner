using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGenerator : MonoBehaviour {

    public ObjectPooler pickupPool;

    public void SpawnPickups(Vector3 startPosition)
    {
        GameObject pickup1 = pickupPool.GetPooledObject();
        pickup1.transform.position = startPosition;
        //pickup1.SetActive(true);
    }

}
