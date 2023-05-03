using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonpresscolors : MonoBehaviour
{
    public SimonSays simon;
    public int buttonIndex;
    private bool pressed=false;
    // Start is called before the first frame update
    public void buttonPressed()

    {
        if (pressed == false)
        {
            pressed = true;
            if (buttonIndex == 4)
            {
                simon.puntoscero();
                simon.indicatorscero();
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

    public void booloprimirfalse()
    {
        pressed = false;
    }
    public void booloprimirtrue()
    {
        pressed = true;
    }
}
