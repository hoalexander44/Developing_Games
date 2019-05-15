using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_script : MonoBehaviour {
    public Sprite pistol;
    public Sprite rifle;
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float angle;
    public GameObject bullet;
    public GameObject bullet2;
    public float speed = 5f;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        //mouse_pos = Input.mousePosition;
        //mouse_pos.x = mouse_pos.x - transform.position.x;
        //mouse_pos.y = mouse_pos.y - transform.position.y;
        //angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (Input.GetButtonDown("E"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = rifle;
        }
        if (Input.GetButtonDown("Q"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = pistol;
        }

    }
    public void Shoot()
    {
        Instantiate(bullet, transform.position,transform.rotation);
    }
    public void Shoot2()
    {
        Instantiate(bullet2, transform.position, transform.rotation);
    }
}
