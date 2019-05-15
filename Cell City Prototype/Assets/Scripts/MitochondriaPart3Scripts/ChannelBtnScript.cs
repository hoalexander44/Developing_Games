using UnityEngine;
using System.Collections;

public class ChannelBtnScript : MonoBehaviour
{

    [SerializeField]
    private GameObject channelTemp;

    public void OnClick()
    {
        GameObject tempThere = GameObject.FindWithTag("MitochondriaChannelTemp");
        GameObject padTemp = GameObject.FindWithTag("MitochondriaPadTemp");
        if (tempThere == null)
        {
            if (padTemp != null)
            {
                Destroy(padTemp);
            }
            Instantiate(channelTemp, transform.position, Quaternion.identity);
        }
    }
}
