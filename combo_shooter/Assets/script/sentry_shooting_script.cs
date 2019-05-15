using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentry_shooting_script : MonoBehaviour {
    [SerializeField]
    private float waittime;
    private float running;
    [SerializeField]
    private GameObject bullet;
	// Use this for initialization
	void Start () {
        running = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (running == 0)
        {
            StartCoroutine("shooting", waittime);
        }
	}
    IEnumerator shooting(float waittime)
    {
        running = 1;
        yield return new WaitForSeconds(waittime);
        Instantiate(bullet, transform.position, transform.rotation);
        running = 0;
    }
}
