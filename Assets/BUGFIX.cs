using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BUGFIX : MonoBehaviour
{
    public UnityEvent LaserON;
    public UnityEvent LaserOFF;

    private void Start()
    {
        LaserON.Invoke();
        Invoke("TriggerEvent", 1f);
    }

    private void TriggerEvent()
    {
        // Invoke the Unity event
        LaserOFF.Invoke();
    }
}

