using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTemplateScript : MonoBehaviour {

    [SerializeField]
    private GameObject finalObject;
    private Vector2 mousePos;
    [SerializeField]
    private LayerMask padLayer;
    [SerializeField]
    private GameObject invalidSpace;

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseRay = Camera.main.ScreenToWorldPoint(transform.position);
            RaycastHit2D rayHit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, padLayer);
            RaycastHit up;
            RaycastHit down;
            Physics.Raycast(transform.position, transform.up, out up, 1f, padLayer);
            Physics.Raycast(transform.position, -transform.up, out down, 1f, padLayer);
            RaycastHit left;
            RaycastHit right;
            Physics.Raycast(transform.position, Vector2.left, out left, 1f, padLayer);
            Physics.Raycast(transform.position, Vector2.right, out right, 1f, padLayer);
            if (rayHit.collider == null)
            {
                if((up.collider != null && up.collider.gameObject.tag == "MitochondriaPad") || (down.collider != null && down.collider.gameObject.tag == "MitochondriaPad") || (left.collider != null && left.collider.gameObject.tag == "MitochondriaPad") || (right.collider != null && right.collider.gameObject.tag == "MitochondriaPad"))
                {
                    Instantiate(finalObject, transform.position, Quaternion.identity);
                    Instantiate(invalidSpace, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
