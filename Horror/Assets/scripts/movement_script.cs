using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_script : MonoBehaviour {

    [SerializeField]
    private float movement;
    [SerializeField]
    private float RotateValue;

    RaycastHit hit;

    private float stopforward;
    private float stopbackward;
    private float stopleft;
    private float stopright;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {


        //Raycast test

        if (Physics.Raycast(transform.position, transform.forward, out hit, 1))
        {
            if (hit.collider.tag == "wall")
            {
                Debug.Log("there is a wall in front of you");
                stopforward = 1;
            }
        }
        else
        {
            stopforward = 0;
        }
        if (Physics.Raycast(transform.position, -transform.forward, out hit, 1))
        {
            if (hit.collider.tag == "wall")
            {
                Debug.Log("there is a wall behind you");
                stopbackward = 1;
            }
        }
        else
        {
            stopbackward = 0;
        }
        if (Physics.Raycast(transform.position, -transform.right, out hit, 1))
        {
            if (hit.collider.tag == "wall")
            {
                Debug.Log("the wall is to the left of you");
                stopleft = 1;
            }
        }
        else
        {
            stopleft = 0;
        }
        if (Physics.Raycast(transform.position, transform.right, out hit, 1))
        {
            if (hit.collider.tag == "wall")
            {
                Debug.Log("the wall is to the right of you");
                stopright = 1;
            }
        }
        else
        {
            stopright = 0;
        }

        //rotation
        if (Input.GetAxisRaw("RJHorizontal") > 0)
        {
            transform.eulerAngles = transform.eulerAngles + new Vector3(0, RotateValue, 0);
        }
        if (Input.GetAxisRaw("RJHorizontal") < 0)
        {
            transform.eulerAngles = transform.eulerAngles - new Vector3(0, RotateValue, 0);
        }

        //movement
        if (Input.GetAxisRaw("LJVertical") > 0)
        {
            if (stopbackward == 0)
            {
                transform.Translate(0, 0, -movement / 8);
            }
        }
        if (Input.GetAxisRaw("LJVertical") < 0)
        {
            if (stopforward == 0)
            {
                 transform.Translate(0, 0, movement / 8);
            }
        }
        if (Input.GetAxisRaw("LJHorizontal") > 0)
        {
            if (stopright == 0)
            {
                transform.Translate(movement / 8, 0, 0);
            }
        }
        if (Input.GetAxisRaw("LJHorizontal") < 0)
        {
            if (stopleft == 0)
            {
                transform.Translate(-movement / 8, 0, 0);
            }
        }


        //relative ray casting


       
    }
}
