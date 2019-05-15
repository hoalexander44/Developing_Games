using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScript : MonoBehaviour {

    [SerializeField]
    private GameObject green;
    [SerializeField]
    private LayerMask layer;
    
    // Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit left;
        RaycastHit right;
        Physics.Raycast(transform.position, Vector2.left, out left, 1f, layer);
        Physics.Raycast(transform.position, Vector2.right, out right, 1f, layer);
        if ((left.collider != null && left.collider.gameObject.tag == "MitochondriaDarkRed") || (right.collider != null && right.collider.gameObject.tag == "MitochondriaDarkRed"))
        {
            Instantiate(green, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
