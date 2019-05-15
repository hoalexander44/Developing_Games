using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuScript : MonoBehaviour {

    public GameObject menu;
    private bool showing = false;

    public void OnClick()
    {
        showing = !showing;
        menu.SetActive(showing);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            this.OnClick();
        }
    }
}
