using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerBtn : MonoBehaviour
{
    public ClickerManager test;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Testing Purposes Only
    public void Click()
    {
        Debug.Log(test.GetmRNA());
    }
}
