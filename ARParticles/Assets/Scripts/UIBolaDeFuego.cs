using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBolaDeFuego : UIController {

    public ParticleSystem[] pss;
    public Slider red;
    public Slider green;
    public Slider blue;

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
                if (i < 2)
                {
                    main.startColor = new Color(red.value, green.value, blue.value,0.2f);
                }
                else
                {
                    main.startColor = new Color(red.value, green.value, blue.value);
                }
            }
        }
    }
}
