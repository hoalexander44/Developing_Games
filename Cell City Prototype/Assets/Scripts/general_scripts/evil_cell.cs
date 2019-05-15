using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evil_cell : MonoBehaviour {
    public int health = 100;
    private float stopper;
    private float damagetime;
    GameObject targetObject;
    private SpriteRenderer spriteRenderer;
    public Sprite damage_sprite;
    public Sprite original;

    //Note: Enemy cell explosion will not work unless there is a Glucose object somewhere in the scene!!!
    public GameObject baseGlucose;

    Rigidbody thisRigidBody;
    
    public int speed;

	// Use this for initialization
	void Start () {

        targetObject = FindGlucose();
        damagetime = (1);
        stopper = 0;

        thisRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(targetObject != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, step);
        }
        else
        {
            targetObject = FindGlucose();
        }
        
        if (health <= 0)
        {
            this.killSelf();
        }
    }

    private void killSelf()
    {
        //Destroy(GetComponent<Rigidbody>());
        //Destroy(GetComponent<Collider2D>());


        //Implement throwing a bunch of Glucose everywhere
        int numberOfGlucose = UnityEngine.Random.Range(4, 6);

        //Probably create a list of glucose objects

        //A list of the Glucose objects that will be created upon the destruction of the enemy cell
        GameObject[] destructionGlucoses = new GameObject[numberOfGlucose];
        glucose glucoseScript;
        //Populate the array:
        for (int i = 0; i < numberOfGlucose; i++)
        {
            destructionGlucoses[i] = Instantiate(baseGlucose, gameObject.transform.position, Quaternion.identity);
            glucoseScript = destructionGlucoses[i].GetComponent<glucose>();
            glucoseScript.moveTo();

            
        }


        //Destroying the cell itself
        Destroy(gameObject);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (health > 0)
        {
            if (col.tag == "Glucose")
            {
                Destroy(col.gameObject);
            }
        }
    }

    public GameObject FindGlucose()
    {
        GameObject[] targets;
        targets = GameObject.FindGameObjectsWithTag("Glucose");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in targets)
        {
            Vector3 diff = go.transform.position - position;
            float currentDistance = diff.sqrMagnitude;
            if (currentDistance < distance)
            {
                closest = go;
                distance = currentDistance;
            }
        }
        return closest;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "weapon")
        {
            if (stopper == 0)
            {
                health -= 10;
                GetComponent<SpriteRenderer>().sprite = damage_sprite;
                Damaged_Function(damagetime);

                //Implment knockback
                //thisRigidBody.isKinematic = false;
            }
        }
    }
    IEnumerator Damaged(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        GetComponent<SpriteRenderer>().sprite = original;
        stopper = 0;
    }
    private void Damaged_Function(float timer)
    {
        StartCoroutine(Damaged(timer));
        stopper = 1;
    }
}
