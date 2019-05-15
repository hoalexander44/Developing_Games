using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {
    private Alex_Ribosome_Box testscript;
    private global_variable_test_script global_script;
    ribosomeBoxScript boxScript;
    GameObject ribosomeBox;
    private CannonBtn clickedBtn;

    void Start ()
    {
        ribosomeBox = GameObject.Find("ribosome_background");

        boxScript = ribosomeBox.GetComponent<ribosomeBoxScript>();
    }

    void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
          PlaceCannon();
        }
    }

    public void PickTower(CannonBtn cannonBtn)
    {
        this.clickedBtn = cannonBtn;
    }

    private void PlaceCannon ()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (global_variable_test_script.protein >= 10 && Alex_Ribosome_Box.allow_placement == 1)
            {
                if(clickedBtn.CannonPrefab != null)
                {
                    GameObject cannon = (GameObject)Instantiate(clickedBtn.CannonPrefab, position, Quaternion.identity);
                    global_variable_test_script.protein -= 10;
                    BuyCannon();
                    Alex_Ribosome_Box.allow_placement = 0;
                }
                
            }
        }
    }

    public void BuyCannon ()
    {
        clickedBtn = null;
    }
}
