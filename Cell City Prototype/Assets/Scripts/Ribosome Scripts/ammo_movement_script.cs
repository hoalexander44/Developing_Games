using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_movement_script : MonoBehaviour
{
    private global_variable_test_script testscript;
    Vector3 targetPosition;
    Vector3 startPosition;
    GameObject target;
    private SpriteRenderer spriteRenderer;
    public string targetTag;
    public Sprite change;
    float horizontalspeed = 0;
    float verticalspeed;
    float absverticalspeed;
    float xdifference;
    float slope;
    float adjuster;
    float realadjuster;
    float verticalspeedsquared;

    GameObject ribosomeBorder;
    // Use this for initialization
    void Start()
    {
        //Sets the ribosome game as its parent
        GameObject parentObject = GameObject.FindWithTag("ribosome_minigame_group");
        this.transform.SetParent(parentObject.transform);

        ribosomeBorder = GameObject.FindWithTag("RibosomeBorder");

        if (GameObject.FindWithTag(targetTag) != null)
        {
            target = FindClosestTarget();
            targetPosition = target.transform.position;
            xdifference = (targetPosition.x - transform.position.x);
            if (xdifference<0)
            {
                xdifference = xdifference * -1;
            }
            if (targetPosition.y - transform.position.y / xdifference< 0){
                slope = (targetPosition.y - transform.position.y / xdifference) * -1;
            }
            else
            {
                slope = (targetPosition.y - transform.position.y / xdifference);
            }
            if (targetPosition.x - transform.position.x != 0 && xdifference>0.5)
            {
                verticalspeed = ((targetPosition.y - transform.position.y) / xdifference);
                if ((targetPosition.x - transform.position.x) > 0)
                {
                    horizontalspeed = 1;
                }
                else
                {
                    horizontalspeed = -1;
                }
            }
            else if (targetPosition.y - transform.position.y<0)
            {
                verticalspeed = -1.41421356237f;
                horizontalspeed = 0;
            }
            else if (targetPosition.y - transform.position.y > 0)
            {
                verticalspeed = 1.41421356237f;
;
                horizontalspeed = 0;
            }
            if (verticalspeed<0)
            {
                absverticalspeed = verticalspeed * -1;
            }
            else
            {
                absverticalspeed = verticalspeed;
            }
            if (targetPosition.x - transform.position.x != 0)
            {
                verticalspeedsquared = (Mathf.Pow(verticalspeed, 2));
                adjuster = (Mathf.Sqrt(verticalspeedsquared + 1));
                realadjuster = Mathf.Sqrt(2) / adjuster;
            }
            else
            {
                realadjuster = 1;
            }


        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void ChooseTargetTag()
    {
        string thisTag = this.gameObject.tag;
        if (thisTag == "GreenBullet")
        {
            targetTag = "ActiveGreen";
        }
        else if (thisTag == "OrangeBullet")
        {
            targetTag = "ActiveOrange";
        }
        else if (thisTag == "PurpleBullet")
        {
            targetTag = "ActivePurple";
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(horizontalspeed * Time.deltaTime*realadjuster*10, verticalspeed * Time.deltaTime*realadjuster*10, 0);
        //if (transform.position.y <= -40 || transform.position.x <= -50 || transform.position.x >= 50 || transform.position.y >= 50)
        //{
        //    Destroy(gameObject);
        //}

        if (ribosomeBorder.GetComponent<Collider2D>().IsTouching(GetComponent<Collider2D>()))
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == targetTag)
        {

            if(targetTag == "ActiveGreen")
            {
                col.GetComponent<SpriteRenderer>().sprite = change;
                col.tag = "InactiveGreen";

                //Change image of target
                //Add one point to score (if all targets destroyed)

                Destroy(gameObject);
            }
            else if(targetTag == "ActiveOrange")
            {
                col.GetComponent<SpriteRenderer>().sprite = change;
                col.tag = "InactiveOrange";
                //Change image of target
                //Add one point to score (if all targets destroyed)

                Destroy(gameObject);
            }
            else if(targetTag == "ActivePurple")
            {
                col.GetComponent<SpriteRenderer>().sprite = change;
                col.tag = "InactivePurple";
                //Change image of target
                //Add one point to score (if all targets destroyed)

                Destroy(gameObject);
            }
        }
        Debug.Log(col.tag);
        if (col.tag == "RibosomeBorder")
        {
            
            Destroy(gameObject);
        }

    }

    public GameObject FindClosestTarget()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(targetTag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }


        return closest;
    }
}
