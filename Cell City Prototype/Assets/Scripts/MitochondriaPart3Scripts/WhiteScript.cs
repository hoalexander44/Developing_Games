using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteScript : MonoBehaviour {

    [SerializeField]
    private GameObject purple;
    [SerializeField]
    private LayerMask layer;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //coll.enabled = !coll.enabled;
        RaycastHit up;
        RaycastHit down;
        Physics.Raycast(transform.position, transform.up, out up, 1f, layer);
        Physics.Raycast(transform.position, -transform.up, out down, 1f, layer);
        if ((up.collider != null && up.collider.gameObject.tag == "MitochondriaPad") || (down.collider != null && down.collider.gameObject.tag == "MitochondriaPad"))
        {
            Instantiate(purple, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
