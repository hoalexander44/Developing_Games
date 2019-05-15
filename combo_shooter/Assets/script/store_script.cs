using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class store_script : MonoBehaviour {
    private float a;
    private float b;
    private float c;
    private float hspeed;
    private float temphspeed;
    private float movestart;
    private float reset_position;
    private float y_pos;
    private float z_pos;
    private Vector3 current_position;
    // Use this for initialization
    void Start () {
        y_pos = transform.position.y;
        z_pos = transform.position.z;
        current_position = transform.position;
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0);
        a = 1;
        b = 0;
        c = 0;
        hspeed = 1.1f;
        movestart = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("l"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, a);
            c = a;
            a = b;
            b = c;


        }
        if (a == 0 && movestart == 0 && this.gameObject.tag == "menu")
        {
            temphspeed = hspeed;
            movestart = 1;
        }
        if (movestart == 1 && this.gameObject.tag == "menu")
        {
            if (temphspeed > 0 && transform.position.x > 3.4)
            {
                transform.Translate(-temphspeed, 0, 0);
                temphspeed -= 0.05f;

            }
            else
            {
                temphspeed = 0;
            }
        }
        if (a == 1 && this.gameObject.tag == "menu")
        {
           
            transform.position = current_position;
            movestart = 0;
        }
        //if (transform.position.x < 3.4f)
        //{
        //    transform.position = new Vector3(3.4f, y_pos, z_pos);
        //}
    }
}
