using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCollectScript : MonoBehaviour {

    public GameObject myParticleEffect;

    float rotate_speed = 200;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //communicate to the player script to get the powerup
            collision.GetComponent<PlayerController>().GetPowerup();

            //make a particle effect at my location
            Instantiate(myParticleEffect,transform.position, Quaternion.identity);

            //destroy the instance so it can't be picked up twice
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.back * rotate_speed * Time.deltaTime );
    }
}
