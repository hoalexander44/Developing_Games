using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_movement_script : MonoBehaviour {
    private float random_number;
    private float random_number2;
    private float vspeed;
	// Use this for initialization
	void Start () {
        random_number = Random.Range(-1.0f, 1.0f);
        random_number2 = Random.Range(2.0f, 10.0f);
        vspeed = random_number2;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(random_number*Time.deltaTime, vspeed * Time.deltaTime, 0);
        if (vspeed != 0)
        {
            vspeed -= 0.01f;
        }
		
	}
}
