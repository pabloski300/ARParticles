using UnityEngine;
using System.Collections;

public class ParticleTrackEvent : DefaultTrackableEventHandler
{

    UIController particleUIController;
    new void  Start()
    {
        base.Start();
       
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        if (!ClickDetection.Instance.hasSelected())
        {
            ClickDetection.Instance.setSelected(particleUIController);
            //particleUIController.SetActive(true);
        }


    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        particleUIController.SetActive(false);
    }

    private void Awake()
    {
        particleUIController = GetComponentInChildren<UIController>();
    }
}
