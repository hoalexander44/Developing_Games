using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_script : MonoBehaviour {
    private tracker_script tracker_scirpt;
    private float attached = 0;
    public static float movement = 1;
    public float mass;
    public float stagnant;
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
    private float stopper=0;
    public float time;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (attached == 1)
        {
            GameObject parentObject = GameObject.FindWithTag("Player");
            this.transform.SetParent(parentObject.transform);
            gameObject.tag = "Player";
            //if (Input.GetAxisRaw("LJHorizontal") > 0)
            //{
            //    transform.Translate(movement / 4, 0, 0);
            //}
            //if (Input.GetAxisRaw("LJHorizontal") < 0)
            //{
            //    transform.Translate(-movement / 4, 0, 0);
            //}
            //if (Input.GetAxisRaw("LJVertical") < 0)
            //{
            //    transform.Translate(0, movement / 4, 0);
            //}
            //if (Input.GetAxisRaw("LJVertical") > 0)
            //{
            //    transform.Translate(0, -movement / 4, 0);
            //}
        }
        if (stagnant == 0)
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
            //The movement restriction
            if (Mathf.Abs(vertical_difference) > 5 || Mathf.Abs(horizontal_difference) > 5)
            {
                //The movement code
                transform.Translate(final_horizontal / 10, final_vertical / 10, 0);
            }
            else
            {
                if (stopper == 0)
                {
                    ShootFunction(time/2);
                }
            }

        }

    }
    private void ShootFunction(float timer)
    {
        StartCoroutine(ShootCoolDown(timer));
        stopper = 1;
    }

    IEnumerator ShootCoolDown(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        if (attached == 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            stopper = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

            if (col.tag == "Player")
            {
                if (tracker_script.mass > 2 * mass)
                {
                    attached = 1;
                    this.tag = "Player";
                    tracker_script.mass += 1;
                    Debug.Log(tracker_script.mass);
                }
            }
        

    }

}



