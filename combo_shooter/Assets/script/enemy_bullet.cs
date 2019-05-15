using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour {
    private stat_script stat_script;
    // Use this for initialization
    void Start () {
        transform.Translate(2, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
    RaycastHit2D hit = (Physics2D.Raycast(transform.position, new Vector2(1, 0), 1, (1 << 8)));
    if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                stat_script.life -= 1;
                Destroy(this.gameObject);
            }
        }
    transform.Translate(25 * Time.deltaTime, 0, 0);
    }
}
