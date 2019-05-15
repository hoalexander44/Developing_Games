using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerManager : MonoBehaviour {
    private float mRNA;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //On Click function (called in Unity Inspector)
    public void Add()
    {
        mRNA += 2;
    }

    public void ClickerUpgrade()
    {
        mRNA -= 10;
    }

    public float GetmRNA()
    {
        return mRNA;
    }
}
