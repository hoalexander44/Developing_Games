using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_item_script : MonoBehaviour {
    private float max;
    private float min;
    private float current;
	// Use this for initialization
	void Start () {
        current = 0;
        max = 0;
        min = -13;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && current > min)
        {
            transform.Translate(0, 1, 0);
            current -= 1;

        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && current < max)
        {
            transform.Translate(0, -1, 0);
            current += 1;

        }
    }
}
