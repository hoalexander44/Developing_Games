using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disapear_script : MonoBehaviour {
    public float start_speed;
    public float slow_down;
    public float die_time;
    private float running;
    private float vspeed;
    private float a;
	// Use this for initialization
	void Start () {
        vspeed = start_speed;
        a = 1f;
        StartCoroutine("die", die_time);
    }
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, a);
        a -= 0.02f;
        transform.Translate(0, vspeed*Time.deltaTime, 0);
        if (vspeed >= 0.1f)
        {
            vspeed -= slow_down;
        }

	}
    IEnumerator die(float die_time)
    {
        running = 1;
        yield return new WaitForSeconds(die_time);
        running = 0;
        Destroy(this.gameObject);
    }
}
