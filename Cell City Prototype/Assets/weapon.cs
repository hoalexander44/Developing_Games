using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {
    public int weaponRotateSpeed = 5;

    private bool shouldSpin;
	// Use this for initialization
	void Start () {
        shouldSpin = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (shouldSpin)
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0, weaponRotateSpeed));
        }   
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyCell")
        {
            shouldSpin = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "EnemyCell")
        {
            shouldSpin = false;
        }
    }
}
