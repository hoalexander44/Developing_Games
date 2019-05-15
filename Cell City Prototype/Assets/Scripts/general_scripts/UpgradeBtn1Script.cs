using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBtn1Script : MonoBehaviour {

    public GameObject prefab;

    public void OnClick()
    {
        Instantiate(prefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }
}
