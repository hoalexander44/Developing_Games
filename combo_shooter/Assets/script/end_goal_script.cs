using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_goal_script : MonoBehaviour {
    private stat_script stat_script;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit2 = (Physics2D.Raycast(transform.position, transform.right, 1, (1 << 9)));
        if (hit2.collider != null)
        {
            if (hit2.collider.gameObject.tag == "enemy")
            {
                Debug.Log("ENEMY MADE IT");
                stat_script.life -= 1;
                hit2.collider.gameObject.GetComponent<enemy_movement_script>().money_gain = 1;
                hit2.collider.gameObject.GetComponent<enemy_movement_script>().Kill();
            }
        }
    }//end of update bracket


}//end of public bracket
