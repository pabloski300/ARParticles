using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
    public GameObject Canvas;
    public void SetActive(bool active)
    {
        Canvas.SetActive(active);
        if (active)
        {
            ExpandMenu[] es = Canvas.GetComponentsInChildren<ExpandMenu>();
            foreach (ExpandMenu e in es)
            {
                e.Restart();
            }
        }
    }
}
