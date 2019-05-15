using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_gun_script : MonoBehaviour {

    private GameObject player;
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float angle;
    public float speed = 5f;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        //Vector2 direction = Camera.main.ScreenToWorldPoint(player.transform.position) - transform.position;
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
