using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ribosomeBoxScript : MonoBehaviour {
    RectTransform rt;
    Renderer rend;

    Ray ray;
    RaycastHit hit;

    private Vector2 mousePos;
    [SerializeField]
    private LayerMask padLayer;

    //Tells if the mouse is over the ribosome box
    private bool mouseIsOverBox;


	// Use this for initialization
	void Start () {
        rt = GetComponent<RectTransform>();
        rend = GetComponent<Renderer>();

        mouseIsOverBox = false;

        Debug.Log("I'm born");
	}
    
    public bool mouseIsInBox()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("The box name is: " + this.transform.name);
            if (hit.transform.name == this.transform.name)
            {
                Debug.Log("In box");
                return true;
            }

        }

        //        float aspectRatio = (float)Screen.width / Screen.height;
        //        if (rend.bounds.Contains(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane))))
        //        {
        //            Debug.Log("In box");
        //            return true;
        //        }
        //        Debug.Log("Not in box");
        //        Debug.Log("Mouse Position: " + Input.mousePosition);
        //        Debug.Log("Box Center: " + rend.bounds.center);
        //Debug.Log("Not in box");
        return false;
    }

    public bool objectIsInBox(GameObject objectToCheck)
    {

        return false;
    }

    private void OnMouseOver()
    {
        Debug.Log("Mouse is over box");
    }

    private void OnMouseDown()
    {
        Debug.Log("Box is clicked");
    }



    // Update is called once per frame
    void Update () {
        Vector2 mouseRay = Camera.main.ScreenToWorldPoint(transform.position);
        RaycastHit2D rayHit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, padLayer);
        //Debug.Log(this.gameObject.tag);
        //Debug.Log(rayHit.collider);
        //if (rayHit.collider.CompareTag("RibosomeBox"))
        //{
          //  Debug.Log("mouse over");
        //}

    }
}
