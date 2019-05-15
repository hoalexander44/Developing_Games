using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_script : MonoBehaviour {
    [SerializeField]
    private float gravity, jump;

    private float vspeed = 0;
    private string state;

    private string facing;

    private Vector3 mousepos;



    //====================================================================================//

    //====================================================================================//
    void Start () {
        state = "air";
        facing = "right";
        
	}







    //====================================================================================//

    //====================================================================================//
    void Update () {

        //to check to see if the player walks off a platform
        RaycastHit2D hit = (Physics2D.Raycast(transform.position, -transform.up,1, (1 << 0)));
       

        if (state == "ground" && hit.collider == null)
        {
            state = "air";
        }
        //Horizontal Movement
        //mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(4 * Time.deltaTime, 0, 0);
            
            //if (facing == "left" &&  mousepos.x > transform.position.x)
            //{
            //    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            //    facing = "right";
            //}
            
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(-4 * Time.deltaTime, 0, 0);

            //Look over how to rotate player while making it feel good
            //if (facing == "right" && mousepos.y < transform.position.x)
            //{
            //    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            //    facing = "left";
            //}

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
        if (collision.collider.tag != "wall")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }//end of OnCollisionEnter2D bracket



}//end of public class bracket
