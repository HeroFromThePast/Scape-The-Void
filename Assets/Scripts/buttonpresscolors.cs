using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonpresscolors : MonoBehaviour
{
    public SimonSays simon;
    public int buttonIndex;
    // Start is called before the first frame update
    public void buttonPressed()

    {
        if(buttonIndex==4)
        {
            simon.GenerateSequence();
            StartCoroutine(simon.PlaySequence());
        }
        else
        {
            simon.checkbutton(buttonIndex);
            simon.PlaySequencePressed(buttonIndex);
        }
    }
}