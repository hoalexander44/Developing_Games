using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back_panel_script : MonoBehaviour {
    public static float turner;
    public string mytag;
    private bool used = false;
    [SerializeField]
    private Canvas tutorial;
	// Use this for initialization
	void Start () {
        mytag = this.gameObject.tag;
	}
	
	// Update is called once per frame
	void Update () {
    }
    void OnMouseDown()
    {
        if (camera_script.minigame == "returned" && mytag == "ribosome_game_camera")
        {
            turner = 1;
        }
        if (camera_script.minigame == "returned" && mytag == "mitochondria_game_camera")
        {
            turner = 2;
        }
        if (camera_script.minigame == "returned" && mytag == "DNAgamecamera")
        {
            turner = 3;
        }
        if (used == false)
        {
            tutorial.gameObject.SetActive(true);
            Time.timeScale = 0f;
            used = true;
        }
    }
}
