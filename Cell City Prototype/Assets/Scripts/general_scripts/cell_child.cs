using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cell_child : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject parentObject = GameObject.FindWithTag("PlayerCell");
        this.transform.SetParent(parentObject.transform);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
