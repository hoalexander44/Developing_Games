using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shooting_script : MonoBehaviour {
    [SerializeField]
    private GameObject bullet,gun; //slots for the bullet that is created and the gun that it is created from for orientation reasons

    //currently irrelevant
    private GameObject detectedenemy;
    private string detectionstorage;
    private RaycastHit2D hit3;



    //determines if bullets or missiles are shot
    string gunmode;
    //shooting lag indicator
    private float running;
    //reloading indicator
    private float running2;
    //shooting lag waittime
    public float waittime;
    //reloading waittime
    public float waittime2;
    //maximum amount of missiles
    private float Max_Ammo;
    //current amount of missiles
    private float Current_Ammo;
    //text to indicate ammo to player
    public Text ammo;
    //text to indicate reloading to player
    public Text Reloading_Text;
    //makes sure reloading and shooting lag dont happen at the same time
    private float stopper;



    // Use this for initialization
    void Start () {
        if (this.gameObject.tag == "Player")
        {
            Reloading_Text.text = "";
        }
        Max_Ammo = 3;
        Current_Ammo = 3;
        running = 0;
        running2 = 0;
        stopper = 0;
        detectionstorage = "empty";
        detectedenemy = null;
        gunmode = "bubble";
    }
	
	// Update is called once per frame
	void Update () {

        //AMMO INDICATOR
        if (this.gameObject.tag == "Player")
        {
            ammo.text = (Current_Ammo) + "/3 MISSILES";
        }

        //GUNMODE CHANGING
        if (Input.GetButtonDown("Q"))
        {
            gunmode = "bubble";
        }
        if (Input.GetButtonDown("E"))
        {
            gunmode = "rifle";
        }
        //hitscanning =================================================================================================

        //RaycastHit2D hit2 = (Physics2D.Raycast(transform.position, transform.right, 5, (1 << 9)));
        //if (hit2.collider != null)
        //{
        //    if (detectedenemy != null)
        //    {
        //        if (hit2.collider.gameObject != detectedenemy && detectionstorage == "full")
        //        {
        //            detectedenemy.GetComponent<enemy_movement_script>().detected = "not detected";
        //            detectedenemy = null;
        //            detectionstorage = "empty";
        //        }
        //        if (hit2.collider.tag == "enemy" && detectionstorage == "empty")
        //        {
        //            if (gunmode == "pistol")
        //            {
        //                detectedenemy = hit2.collider.gameObject;
        //                detectedenemy.gameObject.GetComponent<enemy_movement_script>().detected = "found";
        //                detectionstorage = "full";
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (hit2.collider.tag == "enemy" && detectionstorage == "empty")
        //        {
        //            if (gunmode == "pistol")
        //            {
        //                detectedenemy = hit2.collider.gameObject;
        //                detectedenemy.gameObject.GetComponent<enemy_movement_script>().detected = "found";
        //                detectionstorage = "full";
        //            }
        //        }
        //        if (detectedenemy == null)
        //        {
        //            detectedenemy = null;
        //            detectionstorage = "empty";
        //        }
        //    }
        //}
        //else
        //{
        //    if (detectedenemy != null)
        //    {
        //        detectedenemy.GetComponent<enemy_movement_script>().detected = "not detected";
        //        detectedenemy = null;
        //        detectionstorage = "empty";
        //    }
        //}
        //

        //if (detectedenemy != null && gunmode == "rifle")
        //{
        //    detectedenemy.GetComponent<enemy_movement_script>().detected = "not detected";
        //    detectedenemy = null;
        //    detectionstorage = "empty";
        //    
        //}
        //END OF HIT SCANNING ====================================================================================

        //SHOOTING==============================================================================================
        //
        //SHOOTING==============================================================================================


        //shooting in rifle mode
        if (gunmode == "rifle")
        {
            if (Input.GetMouseButtonDown(0))
            {
                gun.GetComponent<gun_script>().Shoot();
                //Instantiate(bullet, transform.position,transform.rotation);
            }
        }

        //shooting in bubble mode
        if (gunmode == "bubble")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (running == 0 && Current_Ammo > 0 && stopper == 0)
                {
                    gun.GetComponent<gun_script>().Shoot2();
                    Current_Ammo -= 1;
                    StartCoroutine("cooldown", waittime);
                }

                //Instantiate(bullet, transform.position,transform.rotation);
            }
        }


        //automatic reloading
        if (running2 == 0 && Current_Ammo <= 0 && stopper == 0)
        {
            StartCoroutine("cooldown2", waittime2);
        }

        // manual reloading
        if (Input.GetButtonDown("1"))
        {
            if (Current_Ammo < Max_Ammo && Current_Ammo > 0 && running2 == 0)
            {
                stopper = 1;
                StopCoroutine("cooldown");
                running = 0;
                StopCoroutine("cooldown2");
                running2 = 0;
                StartCoroutine("cooldown2", waittime2);


            }
        }


    }//end of Update script


    //Timer for shooting lag
    IEnumerator cooldown(float waittime)
    {
        running = 1;
        yield return new WaitForSeconds(waittime);
        running = 0;
    }

    //Timer for Reloading
    IEnumerator cooldown2(float waittime)
    {
        running2 = 1;
        if (this.gameObject.tag == "Player")
        {
            Reloading_Text.text = "Reloading";
        }
        yield return new WaitForSeconds(waittime);
        if (this.gameObject.tag == "Player")
        {
            Reloading_Text.text = "";
        }
        Current_Ammo = Max_Ammo;
        stopper = 0;
        running2 = 0;
    }
}//end of public class script
