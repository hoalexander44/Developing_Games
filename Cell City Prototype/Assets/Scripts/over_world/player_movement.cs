using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour {
    public static float movement = 1;
    // Use this for initialization
    void Start () {
	}
	//PURPOSE OF THIS SCRIPT IS TO CHECK INPUTS
    //The results of this test is to allow the player to move using controller inputs

	// Update is called once per frame
	void Update () {
	    if(Time.timeScale != 0f)
        {
            //CHECK KEYBOARD INPUTS
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.Translate(movement, 0, 0);
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                transform.Translate(-movement, 0, 0);
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                transform.Translate(0, movement, 0);
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                transform.Translate(0, -movement, 0);
            }
            //TEST LEFT JOYSTICK INPUTS
            if (Input.GetAxisRaw("LJHorizontal") > 0)
            {
                transform.Translate(movement, 0, 0);
            }
            if (Input.GetAxisRaw("LJHorizontal") < 0)
            {
                transform.Translate(-movement, 0, 0);
            }
            if (Input.GetAxisRaw("LJVertical") > 0)
            {
                transform.Translate(0, movement, 0);
            }
            if (Input.GetAxisRaw("LJVertical") < 0)
            {
                transform.Translate(0, -movement, 0);
            }
            //TEST RIGHT JOYSTICK INPUTS
            if (Input.GetAxisRaw("RJHorizontal") > 0)
            {
                transform.Translate(movement, 0, 0);
            }
            if (Input.GetAxisRaw("RJHorizontal") < 0)
            {
                transform.Translate(-movement, 0, 0);
            }
            if (Input.GetAxisRaw("RJVertical") > 0)
            {
                transform.Translate(0, movement, 0);
            }
            if (Input.GetAxisRaw("RJVertical") < 0)
            {
                transform.Translate(0, -movement, 0);
            }
            //TEST CONTROLLER BUTTON INPUTS
            if (Input.GetAxisRaw("BButton") > 0)
            {
                transform.Translate(movement, 0, 0);
            }
            if (Input.GetAxisRaw("XButton") < 0)
            {
                transform.Translate(-movement, 0, 0);
            }
            if (Input.GetAxisRaw("AButton") > 0)
            {
                transform.Translate(0, movement, 0);
            }
            if (Input.GetAxisRaw("YButton") < 0)
            {
                transform.Translate(0, -movement, 0);
            }

        }
    }
}
