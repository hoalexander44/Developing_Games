using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class special_bullet_script : MonoBehaviour {

    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float hspeed;
    private float angle;
    public float speed;
    [SerializeField]
    private GameObject gun;
    private stat_script stat_script;
    private stat_script stat_script2;
    [SerializeField]
    private float bump, damage;
    public GameObject hit_number;
    public GameObject particle;
    // Use this for initialization
    void Start()
    {
        transform.Translate(1, 0, 0);
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        //mouse_pos = Input.mousePosition;
        //mouse_pos.x = mouse_pos.x - transform.position.x;
        //mouse_pos.y = mouse_pos.y - transform.position.y;
        //angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(-2, 0, angle));
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = (Physics2D.Raycast(transform.position, new Vector2(1, 0), 1, (1 << 9)));
        if (hit.collider != null)
        {
            if (hit.collider.tag == "enemy")
            {
                if (hit.collider.gameObject.GetComponent<enemy_movement_script>().state == "ground")
                {
                   
                    hit.collider.gameObject.GetComponent<enemy_movement_script>().health -= damage;
                    hit_number.GetComponent<damage_number_script>().number_changer(5);
                    Instantiate(hit_number, transform.position + ((hit.collider.gameObject.transform.position - transform.position) / 2), hit_number.transform.rotation);
                    Instantiate(particle, transform.position + ((hit.collider.gameObject.transform.position - transform.position) / 2), hit_number.transform.rotation);
                    Instantiate(particle, transform.position + ((hit.collider.gameObject.transform.position - transform.position) / 2), hit_number.transform.rotation);
                    Instantiate(particle, transform.position + ((hit.collider.gameObject.transform.position - transform.position) / 2), hit_number.transform.rotation);
                    Instantiate(particle, transform.position + ((hit.collider.gameObject.transform.position - transform.position) / 2), hit_number.transform.rotation);
                    //hit.collider.gameObject.GetComponent<enemy_movement_script>().state = "air";
                    if (hit.collider.gameObject.GetComponent<enemy_movement_script>().health >0)
                    {
                        hit.collider.gameObject.transform.Translate(0, 1, 0);
                        hit.collider.gameObject.GetComponent<enemy_movement_script>().vspeed += bump;
                    }


                    Destroy(this.gameObject);
                }
                if (hit.collider.gameObject.GetComponent<enemy_movement_script>().state == "air")
                {
                    if (hit.collider.gameObject.GetComponent<enemy_movement_script>().vspeed < 5)
                    {
                        hit.collider.gameObject.GetComponent<enemy_movement_script>().vspeed += 3;
                    }
                    hit.collider.gameObject.GetComponent<enemy_movement_script>().health -= 5;
                    hit_number.GetComponent<damage_number_script>().number_changer(5);
                    Instantiate(hit_number, transform.position + ((hit.collider.gameObject.transform.position - transform.position) / 2), hit_number.transform.rotation);
                    Destroy(this.gameObject);
                }
            }
        }
        transform.Translate(hspeed * Time.deltaTime, 0, 0);
        if (hspeed < 25)
        {
            hspeed += speed;
        }
    }
    //void OnCollisionEnter2D(Collision2D hit)
    //{
        //if (hit.collider.tag == "enemy")
        //{
            //if (hit.collider.gameObject.GetComponent<enemy_movement_script>().state == "ground")
            //{
                //hit.collider.gameObject.GetComponent<enemy_movement_script>().vspeed += bump;
                //hit.collider.gameObject.GetComponent<enemy_movement_script>().health -= damage;
                //hit.collider.gameObject.GetComponent<enemy_movement_script>().state = "air";
        
        
                //Destroy(this.gameObject);
            //}
        //}
    //}
}
