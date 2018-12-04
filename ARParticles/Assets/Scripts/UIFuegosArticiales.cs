using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFuegosArticiales : MonoBehaviour {
    public ParticleSystem[] pss;

    public GameObject Canvas;

    public Slider red;
    public Slider green;
    public Slider blue;

    public Slider particleNumber;

    public Slider emissors;

    // Use this for initialization
    void Start()
    {
        emissors.maxValue = pss.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            foreach(ParticleSystem ps in pss) {
                if (ps.gameObject.activeSelf)
                {
                    var main = ps.main;
                    var emmisor = ps.emission;
                    main.startColor = new Color(red.value, green.value, blue.value);
                    emmisor.rateOverTime = particleNumber.value;
                }
            }

        }
    }

    public void Active()
    {
        for (int i = 0; i<emissors.value; i++)
        {
            pss[i].gameObject.SetActive(true);
        }
        for(int i = pss.Length-1; i > emissors.value-1; i--)
        {
            pss[i].gameObject.SetActive(false);
        }
    }

    public void SetActive(bool active)
    {
        Canvas.SetActive(active);
        this.gameObject.SetActive(active);
    }
}
