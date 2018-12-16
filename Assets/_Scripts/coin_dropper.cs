using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_dropper : MonoBehaviour {

    public GameObject coin;

    public GameObject[] powerups;


    float spawn_timer;
    float min_spawn = 2;
    float max_spawn = 10;

    float p_spawn_timer;
    float p_time_multiple = 3;

	// Use this for initialization
	void Start () {
        spawn_timer = Random.Range(min_spawn, max_spawn);

        p_spawn_timer = Random.Range(min_spawn * p_time_multiple, max_spawn * p_time_multiple);
    }

    // Update is called once per frame
    void Update()
    {
        spawn_timer -= Time.deltaTime;
        p_spawn_timer -= Time.deltaTime;

        if (spawn_timer <= 0)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
            spawn_timer = Random.Range(min_spawn, max_spawn);
        }

        if (p_spawn_timer <= 0)
        {
            Instantiate(powerups[Random.Range(0, powerups.Length - 1)], transform.position, Quaternion.identity);
            p_spawn_timer = Random.Range(min_spawn * p_time_multiple, max_spawn * p_time_multiple);
        }
    }
}
