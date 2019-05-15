using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class return_over_world : MonoBehaviour {
    private camera_script testscript;
    public static float returner_over_world;
    // Use this for initialization
    void Start () {
        returner_over_world = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
        Debug.Log("POOP");
        returner_over_world = 1;
    }
}
