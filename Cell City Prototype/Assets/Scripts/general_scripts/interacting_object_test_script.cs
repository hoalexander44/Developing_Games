using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interacting_object_test_script : MonoBehaviour {
    // Use this for initialization
    private global_variable_test_script testscript;
    void Start () {
        testscript = GameObject.Find("game_master").GetComponent<global_variable_test_script>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Vertical"))
        {
            global_variable_test_script.health = global_variable_test_script.health-10;
            Debug.Log("New Health: " + global_variable_test_script.health);
        }
    }
}
