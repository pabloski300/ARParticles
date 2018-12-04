using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    [SerializeField]
    float rotSpeed = 20f;
    [HideInInspector]
    public bool active = false;

    private void OnMouseDrag()
    {
        if (active)
        {
            Debug.Log("Draging");

            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            //float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

            transform.Rotate(Vector3.up, -rotX);
            //transform.Rotate(Vector3.right, rotY);
        }
    }
}
