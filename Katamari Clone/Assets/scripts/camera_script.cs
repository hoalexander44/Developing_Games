using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour {
    private tracker_script tracker_scirpt;

    //creates a camera variable
    public static Camera camera_component;

    // Use this for initialization
    void Start () {

        //sets the camera_component variable to a component
        camera_component = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        //changes the orthographic size depending on the size of the player
       // camera_component.orthographicSize = 7 + tracker_script.mass / 4;

        //When you press on the righ tbutton orthographic is increased
        if (Input.GetButton("RButton"))
        {
            Debug.Log("HI");
            camera_component.orthographicSize = camera_component.orthographicSize + 1;
        }

        //When you press the left button orthographic is decreasd
        if (Input.GetButton("LButton"))
        {
            Debug.Log("HI");
            if (camera_component.orthographicSize > 7){
                camera_component.orthographicSize = camera_component.orthographicSize - 1;
            }
        }
    }
}
