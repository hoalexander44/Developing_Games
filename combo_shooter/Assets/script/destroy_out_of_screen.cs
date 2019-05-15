using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_out_of_screen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
