using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class channel_one_script : MonoBehaviour {
    public Sprite original;
    public Sprite change;
    private float sprite_changer;
    private global_variable_test_script testscript;
    // Use this for initialization
    void Start () {
        sprite_changer = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
        if (sprite_changer == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = change;
            global_variable_test_script.glucose_intake_level += 1;
            sprite_changer = 2;
        }
        else if (sprite_changer == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = original;
            global_variable_test_script.glucose_intake_level -= 1;
            sprite_changer = 1;
        }
    }
}
