using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stagnant_object_script : MonoBehaviour {
    [SerializeField]
    private float gravity, jump;

    private float vspeed = 0;
    private string state;



    //====================================================================================//

    //====================================================================================//
    void Start()
    {
        state = "air";

    }







    //====================================================================================//

    //====================================================================================//
    void Update()
    {


        //to check to see if the player walks off a platform
        RaycastHit2D hit = (Physics2D.Raycast(transform.position, -transform.up, 1, (1 << 0)));
        if (state == "ground" && hit.collider == null)
        {
            state = "air";
        }

        //States
        if (state == "air")
        {
            transform.Translate(0, vspeed * Time.deltaTime, 0);
            vspeed = vspeed + gravity;

        }
        if (state == "ground")
        {
            if (Input.GetAxisRaw("Jump") > 0)
            {
                vspeed = jump;
                state = "air";
            }

        }

    }//end of UPDATE bracket


    //====================================================================================//
    //OnCollisionEnter2D checks to see if the collided object is wall, and if so
    //changes the state of the object to ground
    //====================================================================================//
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "wall")
        {
            state = "ground";
            vspeed = 0;
        }
    }//end of OnCollisionEnter2D bracket



}
