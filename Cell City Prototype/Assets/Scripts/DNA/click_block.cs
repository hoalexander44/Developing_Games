using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click_block : MonoBehaviour {

    private GameObject strandContainer;

    private bool isActive;

    private float originalSize;

    [SerializeField]
    public Sprite activeSprite;
    [SerializeField]
    public Sprite inactiveSprite;

    private strand_manager strandScript;

    
	// Use this for initialization
	void Start () {
        strandContainer = transform.transform.parent.gameObject;
        strandScript = strandContainer.GetComponent<strand_manager>();

        isActive = false;


        originalSize = this.gameObject.GetComponent<Renderer>().bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        bool changeActiveStatus = strandScript.buttonClicked(this.gameObject);

        if(changeActiveStatus == true)
        {
            this.changeActiveStatus();
        }
    }

    public bool getActiveStatus()
    {
        return isActive;
    }

    private void changeActiveStatus()
    {
        
        if(isActive == false)
        {
            isActive = true;

            GetComponent<SpriteRenderer>().sprite = activeSprite;
        }

        else
        {
            isActive = false;

            GetComponent<SpriteRenderer>().sprite = inactiveSprite;
        }
        
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
