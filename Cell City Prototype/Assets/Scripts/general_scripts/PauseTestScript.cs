using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTestScript : MonoBehaviour {

	// Use this for initialization
	public void OnClick()
    {
        if(Time.timeScale == 1.0f)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
