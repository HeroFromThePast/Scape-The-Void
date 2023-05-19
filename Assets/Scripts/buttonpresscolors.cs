using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonpresscolors : MonoBehaviour
{
    public SimonSays simon;
    public int buttonIndex;
   public bool pressed=true;
    // Start is called before the first frame update

    private void Update()
    {
       
    }

    public void buttonPressed()

    {
        if (pressed == true)
        {
          
            if (buttonIndex == 4)
            {
                simon.puntoscero();
                simon.indicatorscero();
                simon.GenerateSequence();
                simon.
                StartCoroutine(simon.PlaySequence());
                StartCoroutine(simon.PlaySequencePressed(buttonIndex));
            }
            else
            {
                simon.checkbutton(buttonIndex);
                StartCoroutine(simon.PlaySequencePressed(buttonIndex));
            }
        }
        pressed = false;
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
