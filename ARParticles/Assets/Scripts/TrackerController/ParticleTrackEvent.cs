using UnityEngine;
using System.Collections;

public class ParticleTrackEvent : DefaultTrackableEventHandler
{

    UIChispas particleUIController;
    new void  Start()
    {
        base.Start();
       
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        particleUIController.SetActive(true);
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        particleUIController.SetActive(false);
    }

    private void Awake()
    {
        particleUIController = GetComponentInChildren<UIChispas>();
    }
}
