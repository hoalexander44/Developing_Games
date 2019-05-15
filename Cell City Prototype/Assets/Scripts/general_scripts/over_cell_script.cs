using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class over_cell_script : MonoBehaviour {
    private global_variable_test_script testscript;
    private float stopper;
    IEnumerator salt_changer(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        global_variable_test_script.salt -= 10;
        stopper = 0;

    }
    private void salt(float timer)
    {
        StartCoroutine(salt_changer(timer));
    }
    // Use this for initialization
    void Start()
    {
        stopper = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision!");
        global_variable_test_script.salt -= 10;
        if (stopper == 0 && col.gameObject.name == "water_patch")
        {
            salt(5);
            stopper = 1;
        }
    }
}