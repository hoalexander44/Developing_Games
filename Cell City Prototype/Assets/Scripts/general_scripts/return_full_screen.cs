using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class return_full_screen : MonoBehaviour {
    private camera_script testscript;
    public static float returner;
    // Use this for initialization
    void Start () {
        returner = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
       returner = 1;
    }
}
