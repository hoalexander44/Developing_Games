using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner_script : MonoBehaviour {
    [SerializeField]
    private GameObject enemyone, enemytwo, enemythree;
    public float waittime;
    public float waittime2;
    public float waittime3;

    private float running;
    private float running2;
    private float running3;

    private float wave;
    public static float enemyone_number;
    public static float enemytwo_number;
    public static float enemythree_number;

    public static float enemy_alive_number;

    public Text waveText;
    public Text PressP;

    private float wavestarted;
    // Use this for initialization
    void Start () {
        PressP.text = "";
        wave = 1;
        wavestarted = 0;
        running = 0;
        running2 = 0;
        running3 = 0;
        waveText.text = "Wave: " + wave;
    }
	
	// Update is called once per frame
	void Update () {
        if (enemyone_number <= 0 && enemytwo_number <= 0 && enemythree_number <= 0 && enemy_alive_number <=0)
        {
            PressP.text = "PRESS P TO START NEXT WAVE";
            if (Input.GetButtonDown("P"))
            {
                PressP.text = "";
                wave += 1;
                waveText.text = "Wave: " + wave;
                wavestarted = 0;
            }
        }

        if (wave == 1 && wavestarted == 0)
        {
            PressP.text = "";
            enemyone_number = 4;
            enemytwo_number = 0;
            enemythree_number = 0;
            enemy_alive_number = enemyone_number + enemytwo_number + enemythree_number;
            wavestarted = 1;
        }
        if (wave == 2 && wavestarted == 0)
        {
            enemyone_number = 2;
            enemytwo_number = 10;
            enemythree_number = 1;
            enemy_alive_number = enemyone_number + enemytwo_number + enemythree_number;
            waittime = 2;
            waittime2 = 3;
            waittime3 = 30;
            wavestarted = 1;
        }
        if (wave == 3 && wavestarted == 0)
        {
            enemyone_number = 10;
            enemytwo_number = 10;
            enemythree_number = 2;
            enemy_alive_number = enemyone_number + enemytwo_number + enemythree_number;
            waittime2 = 5;
            waittime3 = 15;
            wavestarted = 1;
        }
        if (wave == 4 && wavestarted == 0)
        {
            enemyone_number = 15;
            enemytwo_number = 15;
            enemythree_number = 2;
            enemy_alive_number = enemyone_number + enemytwo_number + enemythree_number;
            waittime = 5;
            waittime2 = 3;
            waittime3 = 10;
            wavestarted = 1;
        }

		if (running == 0)
        {
            if (enemyone_number > 0)
            {
                StartCoroutine("spawner", waittime);
            }
        }
        if (running2 == 0)
        {
            if (enemytwo_number > 0)
            {
                StartCoroutine("spawner2", waittime2);
            }
        }
        if (running3 == 0)
        {
            if (enemythree_number > 0)
            {
                StartCoroutine("spawner3", waittime3);
            }
        }
    }

    IEnumerator spawner(float waittime)
    {
        running = 1;
        yield return new WaitForSeconds(waittime);
        GameObject enemy = Instantiate(enemyone, transform.position, transform.rotation);
        enemy.gameObject.GetComponent<enemy_movement_script>().enemy_type = 1;
        enemyone_number -= 1;
        running = 0;
    }
    IEnumerator spawner2(float waittime2)
    {
        running2 = 1;
        yield return new WaitForSeconds(waittime2);
        GameObject enemy = Instantiate(enemytwo, transform.position, transform.rotation);
        enemy.gameObject.GetComponent<enemy_movement_script>().enemy_type = 2;
        enemytwo_number -= 1;
        running2 = 0;
    }
    IEnumerator spawner3(float waittime2)
    {
        running3 = 1;
        yield return new WaitForSeconds(waittime2);
        GameObject enemy = Instantiate(enemythree, transform.position, transform.rotation);
        enemy.gameObject.GetComponent<enemy_movement_script>().enemy_type = 3;
        enemythree_number -= 1;
        running3 = 0;
    }
}
