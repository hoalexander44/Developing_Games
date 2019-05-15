using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stat_script : MonoBehaviour {
    //the sprites for the player to display if they are hurting
    [SerializeField]
    private Sprite main, damaged;

    //the combo variable that is the basis for the combo mechanic
    public static float combo;

    //texts to display the players
    public Text comboText;
    public Text moneyText;
    public Text lifeText;

    //variable that determines how long it takes before the combo resets
    [SerializeField]
    private float waittime;

    //variable that determines how fast health drops
    [SerializeField]
    private float healthdropwaittime;

    //variable that represents the healthdrop timer running
    public static float running2;

    //variable that represents the combo timer running
    public static float running;

    //helps bullet run the stopcoroutine function
    public static float stopper3;

    //the money the player has, will be consistent
    public static float money;

    //the life the player has, will be consistent
    public static float life;


	// Use this for initialization
	void Start () {
        life = 100;
        running = 0;
        combo = 0;
        lifeText.text = "Life: 0";
        comboText.text = "combo: 0";
        moneyText.text = "money: 0";
        stopper3 = 0;
        money = 1000000;

    }
	
	// Update is called once per frame
	void Update () {
        //This raycasting is to to see if there is a collision with the enemy and if health should be lost
        RaycastHit2D hit2 = (Physics2D.Raycast(transform.position, transform.right, 0.5f, (1 << 9)));
        if (hit2.collider != null)
        {
            if (hit2.collider.tag == "enemy")
            {
                if (running2 == 0)
                {
                    StartCoroutine("healthdrop", healthdropwaittime);
                }
            }
        }

        //this constantly updates the text to represent the combo, money and life
        lifeText.text = "Life: " + life;
        comboText.text = "combo: " + combo;
        moneyText.text = "money: " + money;

        //if statement that decides whether or not the combo counter should be running
        //the combo counter runs when the combo is greater than 0 and if the coroutine is currently NOT running (running == 0)

        if (combo > 0 && running == 0)
        {
            StartCoroutine("combo_timer", waittime);
        }

        //stopper 3 is used so that the bullet script can call upon this static script and have the combo timer stop
        //when a bullet hits an enemy in the air
        if (stopper3 == 1)
        {
            routinestopper();
        }

	}//end up update

    //the timer that will reset the combo after "waittime"
    IEnumerator combo_timer(float waittime)
    {
        running = 1;
        yield return new WaitForSeconds(waittime);
        running = 0;
        money = money + combo;
        combo = 0;
    }

    //the timer that drops health and changes the player into a damage sprite after "healthdropwaittime"
    IEnumerator healthdrop(float waittime)
    {
        running2 = 1;
        life -= 1;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = damaged;
        yield return new WaitForSeconds(waittime);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = main;
        running2 = 0;
    }

    //function that stops the stops the combo timer when the bullet hits enemy in air
    public void routinestopper()
    {
        StopCoroutine("combo_timer");
        running = 0;
        stopper3 = 0;
    }
} // end of public
