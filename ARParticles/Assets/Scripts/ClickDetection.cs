using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetection : MonoBehaviour {

    GameObject selected;
    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
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
                    selected.GetComponent<Rotate>().active = false;
                    selected = hit.collider.gameObject;
                    selected.GetComponent<Rotate>().active = true;
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
