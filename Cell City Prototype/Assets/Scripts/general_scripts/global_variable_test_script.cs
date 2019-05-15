using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global_variable_test_script : MonoBehaviour {
    public static float health = 1000;
    public static float protein = 10000;
    public static float protein_A = 1000;
    public static float protein_B = 0;
    public static float protein_C = 0;
    public static float NADH = 0;
    public static float ATP = 100;
    public static float glucose = 10;
    public static float water = 1000;
    public static float oxygen = 1000;
    public static float carbon_dioxide = 0;
    public static float mRNA = 1000;
    public static float salt = 1000;
    public static float glucose_intake_level = 0;
    public static float DNA_Type = 0; 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Horizontal"))
        {
            Debug.Log("======Stats=====");
            Debug.Log("health: "+ health);
            Debug.Log("protein: " + protein);
            Debug.Log("ATP: " + ATP);
            Debug.Log("glucose: " + glucose);
            Debug.Log("water: " + water);
            Debug.Log("oxygen: " + oxygen);
            Debug.Log("carbon dioxide: " + carbon_dioxide);
            Debug.Log("mRNA: " + mRNA);
            Debug.Log("Salt: " + salt);
            Debug.Log("DNA TYPE: " + DNA_Type);
            Debug.Log("Protein A:" + protein_A);
            Debug.Log("Protein B:" + protein_B);
            Debug.Log("Protein C:" + protein_C);
        }
        if (water <= 0)
        {
            water = 0;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

    public float GetmRNA()
    {
        return mRNA;
    }

    public float GetATP()
    {
        return ATP;
    }

    public float GetProtein()
    {
        return protein;
    }

    public float GetGlucose()
    {
        return glucose;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetWater()
    {
        return water;
    }

    public float GetOxygen()
    {
        return oxygen;
    }

    public float GetSalt()
    {
        return salt;
    }

    public float GetCO2()
    {
        return carbon_dioxide;
    }

    public float GatProteinA()
    {
        return protein_A;
    }

    public float GetProteinB()
    {
        return protein_B;
    }

    public float GetProteinC()
    {
        return protein_C;
    }

    public void Pause()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
