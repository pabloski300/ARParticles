using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetection : MonoBehaviour {

    GameObject selected;
    Camera cam;
    private static ClickDetection _instance;
    public static ClickDetection Instance { get { if (_instance == null) { _instance = FindObjectOfType<ClickDetection>(); } return _instance; } }
    
    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    internal void setSelected(UIController particleUIController)
    {
        if (selected != null)
        {
            selected.GetComponent<Rotate>().active = false;
            selected.GetComponent<UIController>().SetActive(false);
        }
        selected = particleUIController.gameObject;
        selected.GetComponent<Rotate>().active = true;
        particleUIController.SetActive(true);
    }

    internal bool hasSelected()
    {
        return selected == null;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit))
            {
                if(selected != null)
                {
                    setSelected(hit.collider.gameObject.GetComponent<UIController>());
                }
                else
                {
                    selected = hit.collider.gameObject;
                    selected.GetComponent<Rotate>().active = true;
                }

            }
        }
    }
}
