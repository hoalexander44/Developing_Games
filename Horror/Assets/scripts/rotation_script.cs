using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_script : MonoBehaviour {
    [SerializeField]
    private float RotateValue;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetAxisRaw("RJVertical") > 0)
        {
            transform.eulerAngles = transform.eulerAngles + new Vector3(RotateValue, 0,0);
        }
        if (Input.GetAxisRaw("RJVertical") < 0)
        {
            transform.eulerAngles = transform.eulerAngles - new Vector3(RotateValue, 0,0);
        }
    }
}
