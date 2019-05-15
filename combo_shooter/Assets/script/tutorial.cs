using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour {
    private float a;
    private float b;
    private float c;
	// Use this for initialization
	void Start () {
        a = 0;
        b = 1;
        c = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("o"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, a);
            c = a;
            a = b;
            b = c;
                

        }

    }
}
