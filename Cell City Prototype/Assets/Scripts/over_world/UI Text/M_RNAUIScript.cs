﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_RNAUIScript : MonoBehaviour {

    [SerializeField]
    private global_variable_test_script Game_Master;
    public Text myText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        myText.text = "mRNA: " + Game_Master.GetmRNA().ToString();
	}
}
