using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter_block : MonoBehaviour {

    bool isActive;

	// Use this for initialization
	void Start () {
        isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void activateLetter()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        isActive = true;
    }

    public void deactivateLetter()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
        isActive = false;
    }
}
