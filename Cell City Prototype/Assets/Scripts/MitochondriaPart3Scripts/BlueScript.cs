using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueScript : MonoBehaviour {

    [SerializeField]
    private GameObject darkBlue;
    [SerializeField]
    private LayerMask layer;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit up;
        RaycastHit down;
        Physics.Raycast(transform.position, Vector2.up, out up, 1f, layer);
        Physics.Raycast(transform.position, Vector2.down, out down, 1f, layer);
        if ((up.collider != null && up.collider.gameObject.tag == "MitochondriaPurple") || (down.collider != null && down.collider.gameObject.tag == "MitochondriaPurple"))
        {
            Instantiate(darkBlue, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
