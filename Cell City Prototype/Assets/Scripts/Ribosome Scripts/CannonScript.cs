using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    private global_variable_test_script testscript;
    public GameObject bullet;
    private int stopper = 0;
    public string targetTag;
    private GameObject targetobject;
    Vector3 targetposition;
    Vector3 selfposition;
    float angle;
    Vector3 targ;

    GameObject cannonImage;

    float rotateSpeed = 5f;
    public Transform target;

    float cannonY;
    float cannonX;

    float targetY;
    float targetX;

    float xDistance;
    float yDistance;

    float targetToCannonAngle;

    float cannonTargetDistance;

    IEnumerator CannonCoolDown(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        if (GameObject.FindWithTag(targetTag) != null && global_variable_test_script.ATP >=2)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            global_variable_test_script.ATP = global_variable_test_script.ATP - 2;
        }
        stopper = 0;
    }
    private void ShootFunction(float timer)
    {
        StartCoroutine(CannonCoolDown(timer));
        stopper = 1;
    }

    // Use this for initialization
    void Start()
    {
        GameObject parentObject = GameObject.FindWithTag("ribosome_minigame_group");
        this.transform.SetParent(parentObject.transform);
        ChooseTargetTag();
        DontDestroyOnLoad(transform.gameObject);


        if (this.tag == "GreenCannon")
        {
            cannonImage = (GameObject)Instantiate(Resources.Load("Green Cannon Image"), this.transform);
        }
        else if (this.tag == "OrangeCannon")
        {
            cannonImage = (GameObject)Instantiate(Resources.Load("Orange Cannon Image"), this.transform);
        }
        else
        {
            cannonImage = (GameObject)Instantiate(Resources.Load("Purple Cannon Image"), this.transform);
        }

        cannonImage.transform.position = this.transform.position;

        cannonY = cannonImage.transform.position.y;
        cannonX = cannonImage.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if there exists a target
        if (GameObject.FindWithTag(targetTag) != null && stopper == 0)
        {
            targetobject = GameObject.FindWithTag(targetTag);

            //Update coordinates for target
            targetY = targetobject.transform.position.y;
            targetX = targetobject.transform.position.x;
            
            ShootFunction(1f);
            
            faceTarget();
        }

    }

    private void ChooseTargetTag()
    {
        string thisTag = this.gameObject.tag;

        if (thisTag == "GreenCannon")
        {
            targetTag = "ActiveGreen";
        }
        else if (thisTag == "OrangeCannon")
        {
            targetTag = "ActiveOrange";
        }
        else if (thisTag == "PurpleCannon")
        {
            targetTag = "ActivePurple";
        }
    }

    private void faceTarget()
    {

        yDistance = cannonY - targetY;
        xDistance = targetX - cannonX;

        cannonTargetDistance = Mathf.Sqrt(Mathf.Pow(yDistance, 2) + Mathf.Pow(xDistance, 2));


        float numerator = Mathf.Pow(xDistance, 2) - Mathf.Pow(yDistance, 2) + Mathf.Pow(cannonTargetDistance, 2);
        float denominator = 2 * cannonTargetDistance * xDistance;

        targetToCannonAngle = 100 * Mathf.Acos(numerator / denominator);


        if (targetToCannonAngle <= 100)
        {
            cannonImage.transform.eulerAngles = new Vector3(0,0,50f);
        }
        else if (targetToCannonAngle <= 170)
        {
            cannonImage.transform.eulerAngles = new Vector3(0, 0, 0f);
        }
        else if (targetToCannonAngle <= 280)
        {
            cannonImage.transform.eulerAngles = new Vector3(0, 0, 315f);
        }
        else
        {
            cannonImage.transform.eulerAngles = new Vector3(0, 0, 280f);
        }
    }
}