using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandMenu : MonoBehaviour {

    public GameObject Sliders;
    Animator anim;

    bool state = true;

    private void Start()
    {
    }

    public void Expand()
    {
        if (state)
        {
            anim.SetBool("Up",true);
            anim.SetBool("Down", false);
            Sliders.SetActive(false);
            state = false; 
        }
        else
        {
            anim.SetBool("Up", false);
            anim.SetBool("Down", true);
            Sliders.SetActive(true);
            state = true;
        }
    }

    public void Restart()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
        if (!state)
        {
            anim.SetBool("Up", true);
            anim.SetBool("Down", false);
            Sliders.SetActive(false);
            state = false;
        }
        else
        {
            anim.SetBool("Up", false);
            anim.SetBool("Down", true);
            Sliders.SetActive(true);
            state = true;
        }
    }
}
