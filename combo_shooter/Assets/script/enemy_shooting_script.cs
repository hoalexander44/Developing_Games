using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shooting_script : MonoBehaviour {
    public GameObject bullet;
    private float running;
    private float running2;
    private float multishot;
    private float lever; 
    // Use this for initialization
    void Start () {
        running = 0;
        running2 = 0;
        multishot = 0;
        lever = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(multishot);
		if (running == 0 && multishot <3)
        {
            StartCoroutine("cooldown", 0.4f);
        }
        if (running2 == 0 && multishot >=3 )
        {
            StartCoroutine("cooldown2", 4f);
        }
	}
    public void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
    IEnumerator cooldown(float waittime)
    {
        running = 1;
        yield return new WaitForSeconds(waittime);
        Shoot();
        multishot += 1;
        running = 0;
        
    }
    IEnumerator cooldown2(float waittime)
    {
        running2 = 1;
        yield return new WaitForSeconds(waittime);
        multishot = 0;
        running2 = 0;
    }

}
