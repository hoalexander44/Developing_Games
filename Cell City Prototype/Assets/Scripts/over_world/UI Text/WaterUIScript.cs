using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterUIScript : MonoBehaviour {

    [SerializeField]
    private global_variable_test_script Game_Master;
    public Text myText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        myText.text = "Water: " + Game_Master.GetWater().ToString();
	}
}
