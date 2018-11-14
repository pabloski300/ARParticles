using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChispas : MonoBehaviour {

    public ParticleSystem ps;

    public GameObject Canvas;

    public Slider red;
    public Slider green;
    public Slider blue;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        var main = ps.main;
        main.startColor = new Color(red.value,green.value,blue.value);
	}

    public void SetActive(bool active)
    {
        Canvas.SetActive(active);
        this.gameObject.SetActive(active);
    }

}
