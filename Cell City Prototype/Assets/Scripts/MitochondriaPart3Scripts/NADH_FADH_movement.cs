using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NADH_FADH_movement : MonoBehaviour {
    private int movementspeed;
	// Use this for initialzation
	void Start () {
        movementspeed = 1;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(movementspeed*Time.deltaTime, 0, 0);
		
	}
}
