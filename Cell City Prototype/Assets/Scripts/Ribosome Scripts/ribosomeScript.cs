using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ribosomeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //this.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () {

	}

    //When the Ribosome is clicked
    void OnMouseDown()
    {
        Debug.Log("Ribosome Clicked");
        Application.LoadLevel("Ribosome Game");
    }
}
