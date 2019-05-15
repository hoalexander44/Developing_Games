using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alex_Ribosome_Box : MonoBehaviour {
    public static float allow_placement;
	// Use this for initialization
	void Start () {
        allow_placement = 0;

    }
	
	// Update is called once per frame
	void Update () {

	}
    void OnMouseDown()
    {
        Debug.Log("lskdjf");
        allow_placement = 1;
        Debug.Log(allow_placement);
        //StartCoroutine(Placer(2*Time.deltaTime));
    }
    //IEnumerator Placer(float waittime)
    //{
    //    yield return new WaitForSeconds(waittime);
    //    allow_placement = 0;
   //     Debug.Log(allow_placement);
    //}
}
