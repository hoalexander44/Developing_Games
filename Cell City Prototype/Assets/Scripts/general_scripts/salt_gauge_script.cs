using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salt_gauge_script : MonoBehaviour {

    // Use this for initialization
    private global_variable_test_script testscript;
    private float length;
    void Start () {
        length =( this.transform.localScale.x/global_variable_test_script.salt);
        this.transform.localScale = new Vector2(length* global_variable_test_script.salt, 1);
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.localScale = new Vector2(length * global_variable_test_script.salt, 1);
    }
}
