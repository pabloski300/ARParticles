using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandMenu : MonoBehaviour {

    public GameObject Sliders;
    Animator anim;

    bool state = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Expand()
    {
        if (state)
        {
            anim.SetTrigger("RotateUp");
            Sliders.SetActive(false);
            state = false; 
        }
        else
        {
            anim.SetTrigger("RotateDown");
            Sliders.SetActive(true);
            state = true;
        }
    }
}
