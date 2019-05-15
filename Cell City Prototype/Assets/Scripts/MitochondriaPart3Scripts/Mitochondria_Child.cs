using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mitochondria_Child : MonoBehaviour {
    private float stopper = 0;
    private float ATP_Time = 20;
    private global_variable_test_script testscript;
    // Use this for initialization
    void Start () {
        GameObject parentObject = GameObject.FindWithTag("mitochondria_minigame_group");
        this.transform.SetParent(parentObject.transform);

    }
	
	// Update is called once per frame
	void Update () {
    }
}
