using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBtn : MonoBehaviour {
    public ClickerManager test;
    private int level = 0;
    private float elapsed = 0;
    public GameObject clickerBot;
    private Vector3 position = new Vector3(-10f,-2f);
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Every second calls the Add function from the manager for each level purchased
	void Update ()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            for(int i = 0; i < level; i ++)
            {
                test.Add();
            }
            elapsed = elapsed % 1f;
        }
	}

    //On Click Function (called in Unity Inspector)
    public void Click()
    {
        level += 1;
        GameObject bot = Instantiate(clickerBot, position, Quaternion.identity);
        position.x += 1;
        if (position.x >= 11)
        {
            position.x = -10;
            position.y -= 1;
        }
        Debug.Log(test.GetmRNA());
    }
}
