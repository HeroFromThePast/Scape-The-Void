using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] Animator animDoor1;

    [SerializeField] SimonSays simonSaysScript;

    [SerializeField] PuzzleLightsManager lightsPuzzle;

    [SerializeField] UnityEvent ConnectedBateries;



    public int bateries = 0;
    bool bateriesReady = false;

    public int wheels = 0;
    bool wheelsReady = false;

    public void ConnectedBaterie()
    {
        bateries++;
    }

    public void FitWheel()
    {
        wheels++;
    }

    private void Update()
    {
        if (simonSaysScript.ganar == true && lightsPuzzle.ganar == true)
        {
            animDoor1.SetBool("Ready", true);
        }

        if (bateries == 3)
        {
            ConnectedBateries.Invoke();
        }

        if (wheels == 4)
        {
            wheelsReady = true;
        }

    }

}
