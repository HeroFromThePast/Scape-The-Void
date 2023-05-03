using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserDetector : MonoBehaviour
{

    [SerializeField] public UnityEvent onHitByRaycast;
    [SerializeField] public UnityEvent onRaycastLeave;

    [SerializeField] private float currentCountdownTime = 1f;
    private float ResetCountdownTime = 1f;
    [SerializeField] private bool isCountingDown = false;

    bool activated = true;

    private void Start()
    {
        ResetCountdownTime = currentCountdownTime;
    }
    private void Update()
    {
        if (isCountingDown)
        {
            currentCountdownTime -= Time.deltaTime;
            if (currentCountdownTime <= 0f)
            {
                RaycastLeave();
                activated = false;
                isCountingDown = false;
            }
        }
    }

    public void HitByRaycast()
    {
        currentCountdownTime = ResetCountdownTime;
        isCountingDown = true;
        if (activated == false)
        {
            onHitByRaycast.Invoke();
            activated = true;
        } 
    }

    public void RaycastLeave()
    {
        onRaycastLeave.Invoke();
        isCountingDown = false;
    }
}
