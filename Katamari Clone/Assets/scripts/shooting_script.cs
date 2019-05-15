using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_script : MonoBehaviour {
    // Use this for initialization
    //All the variables you would need for a follow script
    Vector3 player_position;
    Vector3 spot;
    public GameObject bullet;
    private float vertical_difference;
    private float horizontal_difference;
    private float final_vertical;
    private float final_horizontal;
    private float divisor;
    public float movement_speed;
    private float test;
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        //Finds the player's position
        var player_position = GameObject.Find("Player").transform.position;
        //Finds th current object's position
        spot = this.transform.position;
        //The vector following math
        vertical_difference = player_position.y - spot.y;
        horizontal_difference = player_position.x - spot.x;
        divisor = Mathf.Sqrt(Mathf.Pow(vertical_difference, 2) + Mathf.Pow(horizontal_difference, 2));
        test = Mathf.Sqrt(Mathf.Pow((horizontal_difference / divisor),2) + Mathf.Pow((vertical_difference / divisor),2));
        final_vertical = vertical_difference / divisor;
        final_horizontal = horizontal_difference / divisor;
        //The movement restriction
        if (Mathf.Abs(vertical_difference) > 5 || Mathf.Abs(horizontal_difference) > 5)
        {
            //The movement code
            transform.Translate(final_horizontal / 10, final_vertical / 10, 0);
        }
        else
        {
            Instantiate(bullet, transform.position,transform.rotation);
        }
        
	}
}
