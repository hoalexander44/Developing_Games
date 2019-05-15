using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement_script : MonoBehaviour {
    private spawner_script spawner_script;
    [SerializeField]
    private float gravity, jump,speed;
    public float money_gain = 0;
    public float health;
    public float enemy_type;

    public float vspeed = 0;
    public string state;
    public string detected;
    private stat_script stat_script;


    //====================================================================================//

    //====================================================================================//
    void Start()
    {
        state = "air";
        detected = "not detected";
    }







    //====================================================================================//

    //====================================================================================//
    void Update()
    {
        if (health <= 0)
        {
            Kill();

        }
        //to check to see if the player walks off a platform
        RaycastHit2D hit = (Physics2D.Raycast(transform.position, -transform.up, 1, (1 << 0)));
        if (state == "ground" && hit.collider == null)
        {
            state = "air";
        }
        if (state == "ground")
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        //States
        if (state == "air")
        {
            transform.Translate(0, vspeed * Time.deltaTime, 0);
            vspeed = vspeed + gravity;

        }
        

    }//end of UPDATE bracket
    public void Manualclick()
    {
        detected = "found";
    }
    public void OnMouseDown()
    {
        if (state == "ground")
        {
            if (detected == "found")
            {
                vspeed = jump;
                health -= 5;
                detected = "not detected";
                state = "air";
            }
        }
    }
    public void Kill()
    {
        if (money_gain == 0)
        {
            stat_script.money += 5;
        }
        spawner_script.enemy_alive_number -= 1;
        Destroy(this.gameObject);
    }

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


}
