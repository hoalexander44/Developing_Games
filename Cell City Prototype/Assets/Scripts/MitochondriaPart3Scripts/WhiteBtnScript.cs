using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBtnScript : MonoBehaviour {

    [SerializeField]
    private GameObject pad;

    public void OnClick()
    {
        GameObject greyTemp = GameObject.FindWithTag("MitochondriaPadTemp");
        GameObject blackTemp = GameObject.FindWithTag("MitochondriaBlackTemp");
        GameObject redTemp = GameObject.FindWithTag("MitochondriaRedTemp");
        GameObject whiteTemp = GameObject.FindWithTag("MitochondriaWhiteTemp");
        GameObject blueTemp = GameObject.FindWithTag("MitochondriaBlueTemp");
        if (whiteTemp == null)
        {
            if (blackTemp != null)
            {
                Destroy(blackTemp);
            }
            else if (redTemp != null)
            {
                Destroy(redTemp);
            }
            else if (greyTemp != null)
            {
                Destroy(greyTemp);
            }
            else if (blueTemp != null)
            {
                Destroy(blueTemp);
            }
            Instantiate(pad, transform.position, Quaternion.identity);
        }
    }
}
