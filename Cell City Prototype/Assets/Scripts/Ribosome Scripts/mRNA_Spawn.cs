using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mRNA_Spawn : MonoBehaviour {
    private global_variable_test_script testscript;
    private int stopper = 0;
    public float timeOne;
    public float timeTwo;
    public int counter = 6;
    private float decider;
    public GameObject codon1;
    public GameObject codon2;
    public GameObject codon3;
   
    IEnumerator Shooter(float waittime, GameObject codon)
    {
        yield return new WaitForSeconds(waittime);
        Instantiate(codon, transform.position,transform.rotation);
        if (codon == codon1)
        {
            global_variable_test_script.mRNA = global_variable_test_script.mRNA - 1;
            Debug.Log("amount of mRNA: " + global_variable_test_script.mRNA);
        }
        stopper = 0;
    }
    private void ShootFunction(float timer,GameObject codon)
    {
        StartCoroutine(Shooter(timer, codon));
        stopper = 1;
        counter = counter + 1;
    }
    void Update ()
    {
    if (stopper==0)
        if (counter == 0 && global_variable_test_script.mRNA>=1)
        {
                ShootFunction(timeTwo,codon1);
        }
        else if (counter<5 && counter>0)
            {
                decider = Random.Range(0f, 1f);
                if (decider < 0.5){
                    ShootFunction(timeOne, codon2);
                }
                else if (decider > 0.5){
                    ShootFunction(timeOne, codon3);
                }
                //Debug.Log(decider);
            }
        if (counter>=5)
        {
            counter = 0;
        }

    }
}
