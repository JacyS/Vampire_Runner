using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfTriggerScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponentInParent<WolfScript>().MyTrigger();
        }
    }
}
