using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class mRNA_Block : MovingObject
{
    private global_variable_test_script testscript;
    public float movementSpeed = -5f;
    string thisTag;

    GameObject ribosomeBox, thisGameObject, mrnaSpawner;
    BoxCollider2D ribosomeBoxCollider, thisGameObjectCollider;

    protected override void Start()
    {
        //Sets the ribosome game as its parent
        GameObject parentObject = GameObject.FindWithTag("ribosome_minigame_group");
        this.transform.SetParent(parentObject.transform);

        base.Start();
        thisTag = this.gameObject.tag;

        thisGameObject = this.gameObject;
        thisGameObjectCollider = thisGameObject.GetComponent<BoxCollider2D>();

        mrnaSpawner = GameObject.Find("UAC Spawner");

        ribosomeBox = GameObject.Find("ribosome_background");
        if (ribosomeBox != null)
        {
            
            ribosomeBoxCollider = ribosomeBox.GetComponent<BoxCollider2D>();
        }
        else
        {
            Debug.Log("Could not find the ribosome game background");
        }
    }

    private bool isInBox()
    {

        if (Vector3.Distance(this.transform.position, mrnaSpawner.transform.position) < ribosomeBoxCollider.bounds.size.x)
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime, 0, 0);
        if (!isInBox())
        {
            if(this.tag == "InactiveOrange" || this.tag == "InactiveGreen" || this.tag == "InactivePurple")
            {
                if (global_variable_test_script.DNA_Type == 1)
                {
                    global_variable_test_script.protein_A = global_variable_test_script.protein_A + 1;
                }
                else if (global_variable_test_script.DNA_Type == 2)
                {
                    global_variable_test_script.protein_B = global_variable_test_script.protein_B + 1;
                }
                else if (global_variable_test_script.DNA_Type == 3)
                {
                    global_variable_test_script.protein_C = global_variable_test_script.protein_C + 1;
                }
                global_variable_test_script.protein = global_variable_test_script.protein + 1;
                Debug.Log("Protein A: "+ global_variable_test_script.protein_A);
            }
            Destroy(gameObject);
        }
    }
}
