using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoScrollForMore : MonoBehaviour {

    [Header("RESOURCES")]
    public Scrollbar listScrollbar;
    public Animator SFMAnimator;

    [Header("SETTINGS")]
    public float fadeOutValue;

    void Update ()
    {
		if(listScrollbar.value >= fadeOutValue)
        {
            SFMAnimator.Play("SFM In");
        }

        else
        {
            SFMAnimator.Play("SFM Out");
        }
	}
}
