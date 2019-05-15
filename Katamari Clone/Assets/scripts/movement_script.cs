using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_script : MonoBehaviour {
    private tracker_script tracker_scirpt;
    public static float movement = 1;
    Vector3 spot;
    // Use this for initialization
    void Start () {
        spot = this.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale != 0f)
        {
  
            if (Input.GetAxisRaw("LJHorizontal") > 0)
            {
                transform.Translate(movement / 8, 0, 0);
            }
            if (Input.GetAxisRaw("LJHorizontal") < 0)
            {
                transform.Translate(-movement / 8, 0, 0);
            }
            if (Input.GetAxisRaw("LJVertical") < 0)
            {
                transform.Translate(0, movement / 8, 0);
            }
            if (Input.GetAxisRaw("LJVertical") > 0)
            {
                transform.Translate(0, -movement / 8, 0);
            }
        }
    }
}
