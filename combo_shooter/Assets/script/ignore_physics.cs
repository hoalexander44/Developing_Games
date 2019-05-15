using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignore_physics : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "wall")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }//end of OnCollisionEnter2D bracket
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag != "wall")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }//end of OnCollisionEnter2D bracket
}
