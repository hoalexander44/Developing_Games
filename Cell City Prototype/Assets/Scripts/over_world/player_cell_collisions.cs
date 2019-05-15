using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_cell_collisions : MonoBehaviour {
    private global_variable_test_script testscript;
    private float stopper = 0;
    public float salt_Time;
    private float stoppertwo = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.zero;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "salt")
        {
           if (stopper == 0)
            {
                Salt_Gain_Function(salt_Time);
            }
        }
        if (col.tag == "water")
        {
            if (stoppertwo == 0)
            {
                Water_Gain_Function(salt_Time);
            }
        }
        //if (col.tag == "EnemyCell")
        //{
        //    Debug.Log("PLAYER HIT BY ENEMY CELL!!");
        //}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Glucose")
        {
            global_variable_test_script.glucose += (global_variable_test_script.glucose_intake_level * 3) + 1;
            Destroy(col.gameObject);
            Debug.Log("Glucose Eaten!!");
        }
        if (col.tag == "salt")
        {
            stopper = 0;
        }
        if (col.tag == "water")
        {
            stoppertwo = 0;
        }
    }
    IEnumerator Salt_Gain(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        global_variable_test_script.water -= (global_variable_test_script.glucose_intake_level*2)+1;
        stopper = 0;
    }
    private void Salt_Gain_Function(float timer)
    {
        StartCoroutine(Salt_Gain(timer));
        stopper = 1;
    }
    IEnumerator Water_Gain(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        global_variable_test_script.water += (global_variable_test_script.glucose_intake_level * 2) + 1;
        stoppertwo = 0;
    }
    private void Water_Gain_Function(float timer)
    {
        StartCoroutine(Water_Gain(timer));
        stoppertwo = 1;
    }
}
