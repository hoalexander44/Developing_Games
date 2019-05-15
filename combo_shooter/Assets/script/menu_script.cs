using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_script : MonoBehaviour {
    private creation_script creation_script;
    public float menu_identity;
    public Sprite sentry_open;
    public Sprite sentry_close;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (creation_script.buy_mode == menu_identity)
        {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = sentry_close; 
        }
        else
        {
            change_normal();
        }

    }

    void change_normal()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sentry_open;
    }
}
