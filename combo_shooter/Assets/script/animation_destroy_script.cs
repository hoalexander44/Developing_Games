using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_destroy_script : MonoBehaviour {
    public float delay;

        // Use this for initialization
        void Start()
        {
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        }
}
