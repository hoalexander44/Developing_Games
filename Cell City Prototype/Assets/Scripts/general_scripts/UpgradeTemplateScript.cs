using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTemplateScript : MonoBehaviour {

    [SerializeField]
    private GameObject finalObject;
    private global_variable_test_script testscript;

    private void Start()
    {
        this.gameObject.SetActive(true);
        this.gameObject.layer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseRay = Camera.main.ScreenToWorldPoint(transform.position);
            RaycastHit2D rayHit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity);
            if(rayHit.collider != null && rayHit.collider.gameObject.tag == "upgrade_placement_pad")
            {
                if (global_variable_test_script.protein_A >= 10)
                {
                    Instantiate(finalObject, transform.position, Quaternion.identity);
                    global_variable_test_script.protein_A = global_variable_test_script.protein_A - 10;
                }
                Destroy(this.gameObject);
            }
        }
    }
}
