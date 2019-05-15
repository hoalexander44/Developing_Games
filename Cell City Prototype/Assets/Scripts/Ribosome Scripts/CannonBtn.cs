using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBtn : MonoBehaviour {
    [SerializeField]
    private GameObject cannonPrefab;
    public GameObject CannonPrefab
    {
        get
        {
            return cannonPrefab;
        }
    }
}
