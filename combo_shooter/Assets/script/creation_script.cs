using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creation_script : MonoBehaviour {
    private stat_script stat_script;
    public GameObject sentry_1;
    public GameObject sentry_2;
    public static float buy_mode;

    private float x_loc;
    private float y_loc;
    private float z_loc;
	// Use this for initialization
	void Start () {
        buy_mode = -1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("2"))
        {
            buy_mode = 2;
        }
        if (Input.GetButtonDown("3"))
        {
            buy_mode = 3;
        }
        if (Input.GetButtonDown("K"))
        {
            if (buy_mode == 2 && stat_script.money >= 1)
            {
                x_loc = transform.position.x+1;
                y_loc = transform.position.y;
                z_loc = transform.position.z;
                Instantiate(sentry_1, new Vector3(x_loc, y_loc, z_loc), transform.rotation);
                stat_script.money -= 1;
            }
            if (buy_mode == 3 && stat_script.money >= 1)
            {
                x_loc = transform.position.x + 1;
                y_loc = transform.position.y;
                z_loc = transform.position.z;
                Instantiate(sentry_2, new Vector3(x_loc, y_loc, z_loc), transform.rotation);
                stat_script.money -= 1;
            }
        }
    }
}
