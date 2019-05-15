using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class To_Cell_world_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }
    void OnMouseDown()
    {
        Debug.Log("Ribosome Clicked");
        Application.LoadLevel("Cell Scene");
    }
}
