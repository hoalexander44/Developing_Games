using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_number_script : MonoBehaviour {
    public Sprite damage_number_1;
    public Sprite damage_number_5;
    public float number;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void number_changer(float number)
    {
        if (number == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = damage_number_1;
        }
        if (number == 5)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = damage_number_5;
        }
    }
}
