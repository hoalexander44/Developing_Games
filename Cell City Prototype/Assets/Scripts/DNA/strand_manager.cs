using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strand_manager : MonoBehaviour {
    private global_variable_test_script test_script;
    //This counts how many buttons are clicked. If number exceeds 2, do not accept click
    int blocksClicked;

    [SerializeField]
    GameObject aBlock;
    [SerializeField]
    GameObject bBlock;
    [SerializeField]
    GameObject cBlock;

    letter_block aBlockScript;
    letter_block bBlockScript;
    letter_block cBlockScript;

    public int numberOfClickBoxes = 4;

    private bool[] buttonArray;
    // Use this for initialization
    void Start () {
        blocksClicked = 0;

        aBlockScript = aBlock.GetComponent<letter_block>();
        bBlockScript = bBlock.GetComponent<letter_block>();
        cBlockScript = cBlock.GetComponent<letter_block>();

        buttonArray = new bool[numberOfClickBoxes];
        //Set all the buttons to off
        for (int i = 0; i < buttonArray.Length; i++)
        {
            buttonArray[i] = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Gets the button that was clicked, and returns if the button should be activated or not
    public bool buttonClicked(GameObject clickedButton)
    {
        bool result = false;

        click_block buttonScript = clickedButton.GetComponent<click_block>();
        if (buttonScript.getActiveStatus() == false)
        {
            if (blocksClicked < 2)
            {
                blocksClicked++;
                print("Click accepted");

                //Update button array
                if(clickedButton.tag == "click_block_one")
                {
                    buttonArray[0] = true;
                }
                else if (clickedButton.tag == "click_block_two")
                {
                    buttonArray[1] = true;
                }
                else if (clickedButton.tag == "click_block_three")
                {
                    buttonArray[2] = true;
                }
                else
                {
                    buttonArray[3] = true;
                }

                result = true;
            }
        }
        else
        {
            if(blocksClicked > 0)
            {
                blocksClicked--;
            }

            //Update button array
            if (clickedButton.tag == "click_block_one")
            {
                buttonArray[0] = false;
            }
            else if (clickedButton.tag == "click_block_two")
            {
                buttonArray[1] = false;
            }
            else if (clickedButton.tag == "click_block_three")
            {
                buttonArray[2] = false;
            }
            else
            {
                buttonArray[3] = false;
            }

            
            result = true;
        }

        if(blocksClicked < 2)
        {
            aBlockScript.deactivateLetter();
            bBlockScript.deactivateLetter();
            cBlockScript.deactivateLetter();
        }
        else
        {
            this.updateLetter();
        }
        

        return result;
    }

    private void updateLetter()
    {
        //First and second buttons clicked
        if(buttonArray[0] && buttonArray[1])
        {
            aBlockScript.activateLetter();

            bBlockScript.deactivateLetter();
            cBlockScript.deactivateLetter();
            global_variable_test_script.DNA_Type = 1;
        }
        //First and third buttons clicked
        else if (buttonArray[0] && buttonArray[2])
        {
            aBlockScript.activateLetter();
            bBlockScript.activateLetter();

            cBlockScript.deactivateLetter();
            global_variable_test_script.DNA_Type = 2;
        }
        //First and fourth buttons clicked
        else if (buttonArray[0] && buttonArray[3])
        {
            aBlockScript.activateLetter();
            bBlockScript.activateLetter();
            cBlockScript.activateLetter();
            global_variable_test_script.DNA_Type = 3;
        }
        //Second and third buttons clicked
        else if (buttonArray[1] && buttonArray[2])
        {
            aBlockScript.deactivateLetter();
            cBlockScript.deactivateLetter();

            bBlockScript.activateLetter();
            global_variable_test_script.DNA_Type = 0;
        }
        //Third and fourth buttons clicked
        else if (buttonArray[2] && buttonArray[3])
        {
            aBlockScript.deactivateLetter();
            bBlockScript.deactivateLetter();

            cBlockScript.activateLetter();
            global_variable_test_script.DNA_Type = 0;
        }
        //Second and fourth buttons clicked
        else if (buttonArray[1] && buttonArray[3])
        {
            aBlockScript.deactivateLetter();

            cBlockScript.activateLetter();
            bBlockScript.activateLetter();
            global_variable_test_script.DNA_Type = 0;
        }
    }
}
