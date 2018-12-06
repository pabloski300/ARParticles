using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
    public GameObject Canvas;
    public void SetActive(bool active)
    {
        Canvas.SetActive(active);
    }
}
