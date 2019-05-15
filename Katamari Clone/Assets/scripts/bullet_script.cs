using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script : MonoBehaviour
{

    Vector3 player_position;
    Vector3 spot;
    private float vertical_difference;
    private float horizontal_difference;
    private float final_vertical;
    private float final_horizontal;
    private float divisor;
    public float movement_speed;
    private float test;
    // Use this for initialization
    void Start()
    {
        //Finds the player's position
        var player_position = GameObject.Find("Player").transform.position;
        //Finds th current object's position
        spot = this.transform.position;
        //The vector following math
        vertical_difference = player_position.y - spot.y;
        horizontal_difference = player_position.x - spot.x;
        divisor = Mathf.Sqrt(Mathf.Pow(vertical_difference, 2) + Mathf.Pow(horizontal_difference, 2));
        test = Mathf.Sqrt(Mathf.Pow((horizontal_difference / divisor), 2) + Mathf.Pow((vertical_difference / divisor), 2));
        final_vertical = vertical_difference / divisor;
        final_horizontal = horizontal_difference / divisor;
       

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(final_horizontal/3, final_vertical/3, 0);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
