using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBlackHole : UIController {

    public ParticleSystem[] pss;
    public ParticleSystem piedras;
    public Slider red;
    public Slider green;
    public Slider blue;
    public Slider stoneNumber;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.activeSelf)
        {
            for (int i = 0; i < pss.Length; i++)
            {
                var main = pss[i].main;
                if (i > 2)
                {
                    main.startColor = new Color(red.value, green.value, blue.value, 0.2f);
                }
                else
                {
                    main.startColor = new Color(red.value, green.value, blue.value);
                }
            }
            var emmisor = piedras.emission;
            emmisor.rateOverTime = stoneNumber.value;
        }
    }
}
