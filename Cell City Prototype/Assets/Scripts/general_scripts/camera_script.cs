using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour {
    Vector3 camera_position;
    GameObject ribosome_game;
    public static float stopper;
    public static string minigame;
    public static Camera camera_component;
    private back_panel_script testscript;
    private  return_full_screen testscript2;
    private return_over_world testscript3;
    Vector3 ribosome_game_location;
    Vector3 ribosome_minigame_position;
    private float movement_counter;
    private float original_orthograpic_size;
    // Use this for initialization
    void Start () {
        camera_position = this.transform.position;
        Debug.Log(camera_position);
        ribosome_game_location = new Vector3 (1, 0);
        camera_component = GetComponent<Camera>();
        minigame = "returned";
        ribosome_minigame_position = new Vector3(camera_position.x + 29, camera_position.y - 8, camera_position.z);
        original_orthograpic_size = camera_component.orthographicSize;

        
	}
	
	// Update is called once per frame
	void Update () {
		if (back_panel_script.turner==1 && stopper ==0)
        {
            transform.Translate(29, -8, 0);
            camera_component.orthographicSize = 7;
            return_full_screen.returner = 0;
            minigame = "ribosome";
            stopper = 1;
        }
        if (back_panel_script.turner == 2 && stopper == 0)
        {
            transform.Translate(-23,6, 0);
            camera_component.orthographicSize = 5;
            return_full_screen.returner = 0;
            minigame = "mitochondria";
            stopper = 1;
        }
        if (back_panel_script.turner == 3 && stopper == 0)
        {
            transform.Translate(18, 12, 0);
            camera_component.orthographicSize = 5;
            return_full_screen.returner = 0;
            minigame = "DNA";
            stopper = 1;
        }
        if (return_full_screen.returner == 1)
        {
            if (minigame == "ribosome")
            {
                transform.Translate(-29, 8, 0);
                camera_component.orthographicSize = original_orthograpic_size;
                back_panel_script.turner = 0;
            }
            if (minigame == "mitochondria")
            {
                transform.Translate(23, -6, 0);
                camera_component.orthographicSize = original_orthograpic_size;
                back_panel_script.turner = 0;
            }
            if (minigame == "over_world")
            {
                camera_component.orthographicSize = original_orthograpic_size;
                return_over_world.returner_over_world = 0;
            }
            if (minigame == "DNA")
            {
                transform.Translate(-18, -12, 0);
                camera_component.orthographicSize = original_orthograpic_size;
                back_panel_script.turner = 0;
            }
            minigame = "returned";
            stopper = 0;
            return_full_screen.returner = 0;
        }
        if (return_over_world.returner_over_world == 1)
        {
            if (minigame == "returned")
            {
                camera_component.orthographicSize = 80;
                minigame = "over_world";
            }
            return_over_world.returner_over_world = 0;
        }
    }
}
