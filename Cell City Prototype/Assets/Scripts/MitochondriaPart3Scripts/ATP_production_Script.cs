using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATP_production_Script : MonoBehaviour {
    private float stopper = 0;
    private float ATP_Time = 5;
    private global_variable_test_script testscript;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (stopper == 0)
        {
            ATP_Gain_Function(ATP_Time);
        }
    }
    IEnumerator ATP_Gain(float waittime)
    {
            yield return new WaitForSeconds(waittime);
            if (global_variable_test_script.glucose >= 1 && global_variable_test_script.oxygen >= 20)
            {
                global_variable_test_script.ATP += 32;
                global_variable_test_script.glucose -= 1;
                global_variable_test_script.oxygen -= 20;
                global_variable_test_script.water += 10;
                global_variable_test_script.carbon_dioxide += 20;
            }
            stopper = 0;
    }
    private void ATP_Gain_Function(float timer)
    {
        StartCoroutine(ATP_Gain(timer));
        stopper = 1;
    }
}
