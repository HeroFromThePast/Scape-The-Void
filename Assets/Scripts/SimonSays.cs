using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    public GameObject whiteButton;
    public List<GameObject> buttons;
    public int sequenceLength;
    public float sequenceDelay;
    public float sequenceDelayPressed;
    private Ray ray;
    private RaycastHit hit;
    private List<int> sequence = new List<int>();
    private int currentIndex = 0;
    private bool playerTurn = false;
    private Color colorWhite;
    private Color colorRed;
    private Color colorBlue;
    private Color colorgreen;
    private Color coloryellow;
    private Color colorRedlit;
    private Color colorBlueLit;
    private Color colorGreenLit;
    private Color colorYellowLit;
    private Color colorWhitelit;

    // Start is called before the first frame update
    void Start()
    {
        colorWhite = whiteButton.gameObject.GetComponent<Renderer>().material.color;
        colorRed = buttons[0].gameObject.GetComponent<Renderer>().material.color;
       colorBlue = buttons[1].gameObject.GetComponent<Renderer>().material.color;
        colorgreen = buttons[2].gameObject.GetComponent<Renderer>().material.color;
         coloryellow = buttons[3].gameObject.GetComponent<Renderer>().material.color;
         colorRedlit = new Color(buttons[0].gameObject.GetComponent<Renderer>().material.color.r + 0.3f, buttons[0].gameObject.GetComponent<Renderer>().material.color.g, buttons[0].gameObject.GetComponent<Renderer>().material.color.b, buttons[0].gameObject.GetComponent<Renderer>().material.color.a);
        colorBlueLit = new Color(buttons[1].gameObject.GetComponent<Renderer>().material.color.r , buttons[1].gameObject.GetComponent<Renderer>().material.color.g, buttons[1].gameObject.GetComponent<Renderer>().material.color.b + 0.3f, buttons[1].gameObject.GetComponent<Renderer>().material.color.a);
      colorGreenLit = new Color(buttons[2].gameObject.GetComponent<Renderer>().material.color.r, buttons[2].gameObject.GetComponent<Renderer>().material.color.g + 0.3f, buttons[2].gameObject.GetComponent<Renderer>().material.color.b , buttons[2].gameObject.GetComponent<Renderer>().material.color.a);
         colorYellowLit = new Color(buttons[3].gameObject.GetComponent<Renderer>().material.color.r, buttons[3].gameObject.GetComponent<Renderer>().material.color.g + 0.3f, buttons[3].gameObject.GetComponent<Renderer>().material.color.b, buttons[3].gameObject.GetComponent<Renderer>().material.color.a);
        colorWhitelit = Color.gray;

    }

    // Update is called once per frame
    void Update()
    {
        /*ray =
          Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.transform.name == "Button_Object_start")
                {
                    StartCoroutine(PlaySequencePressed(4));
                    GenerateSequence();
                    StartCoroutine(PlaySequence());
                }
                if (hit.collider != null && hit.collider.transform.name == "Button_Object_red")
                {
                    StartCoroutine(PlaySequencePressed(0));
                }
                if (hit.collider != null && hit.collider.transform.name == "Button_Object_blue")
                {
                    StartCoroutine(PlaySequencePressed(1));
                }
                if (hit.collider != null && hit.collider.transform.name == "Button_Object_green")
                {
                    StartCoroutine(PlaySequencePressed(2));
                }
                if (hit.collider != null && hit.collider.transform.name == "Button_Object_yellow")
                {
                    StartCoroutine(PlaySequencePressed(3));
                }
            }
        }
        if (playerTurn)
        {
            // check if player clicked the correct button
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit))
                {

                    if (hit.collider != null && hit.collider.gameObject == buttons[sequence[currentIndex]])
                    {
                        currentIndex++;
                    }
                    else
                    {
                        Debug.Log("Game Over");
                    }

                    if (currentIndex == sequence.Count)
                    {
                        Debug.Log("Sequence Complete");
                        playerTurn = false;
                        currentIndex = 0;
                       
                    }
                }
            }
        }*/
    }

    public void checkbutton(int buttonIndex)
    {
        if(buttonIndex== sequence[currentIndex])
        {
            currentIndex++;
        }
        else
        {
            Debug.Log("Game Over");
        }

        if (currentIndex == sequence.Count)
        {
            Ganaste();
            Debug.Log("Sequence Complete");
            playerTurn = false;
            currentIndex = 0;
           
        }
    }

    public void Ganaste()
    {

    }

    public void GenerateSequence()
    {
        sequence.Clear();

        for (int i = 0; i < sequenceLength; i++)
        {
            sequence.Add(Random.Range(0, buttons.Count));
        }
    }

  public  IEnumerator PlaySequence()
    {
        yield return new WaitForSeconds(0.3f);

        foreach (int i in sequence)
        {
            if(buttons[i].gameObject.GetComponent<Renderer>().material.color==colorRed)
            {
                buttons[i].gameObject.GetComponent<Renderer>().material.color = colorRedlit;
            }
            else if (buttons[i].gameObject.GetComponent<Renderer>().material.color == colorBlue)
            {
                buttons[i].gameObject.GetComponent<Renderer>().material.color = colorBlueLit;
            }
            else if (buttons[i].gameObject.GetComponent<Renderer>().material.color == colorgreen)
            {
                buttons[i].gameObject.GetComponent<Renderer>().material.color = colorGreenLit;
            }

            else if (buttons[i].gameObject.GetComponent<Renderer>().material.color == coloryellow)
            {
                buttons[i].gameObject.GetComponent<Renderer>().material.color = colorYellowLit;
            }

            //buttons[i].GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(sequenceDelay);

            if (buttons[i].gameObject.GetComponent<Renderer>().material.color == colorRedlit)
            {
                buttons[i].gameObject.GetComponent<Renderer>().material.color = colorRed;
            }
            else if (buttons[i].gameObject.GetComponent<Renderer>().material.color == colorBlueLit)
            {
                buttons[i].gameObject.GetComponent<Renderer>().material.color = colorBlue;
            }
            else if (buttons[i].gameObject.GetComponent<Renderer>().material.color == colorGreenLit)
            {
                buttons[i].gameObject.GetComponent<Renderer>().material.color = colorgreen;
            }

            else if (buttons[i].gameObject.GetComponent<Renderer>().material.color == colorYellowLit)
            {
                buttons[i].gameObject.GetComponent<Renderer>().material.color = coloryellow;
            }

            //buttons[i].GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(sequenceDelay);
        }

        playerTurn = true;
    }


   public IEnumerator PlaySequencePressed(int i)
    {
        yield return new WaitForSeconds(0.3f);

        
            if (i==0)
            {
                buttons[0].gameObject.GetComponent<Renderer>().material.color = colorRedlit;
            }
            else if (i == 1)
            {
                buttons[1].gameObject.GetComponent<Renderer>().material.color = colorBlueLit;
            }
            else if (i == 2)
            {
                buttons[2].gameObject.GetComponent<Renderer>().material.color = colorGreenLit;
            }

            else if (i == 3)
            {
                buttons[3].gameObject.GetComponent<Renderer>().material.color = colorYellowLit;
            }
        else if  (i==4)
        {
            whiteButton.gameObject.GetComponent<Renderer>().material.color = colorWhitelit;
        }

        //buttons[i].GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(sequenceDelayPressed);

            if (i==0)
            {
                buttons[0].gameObject.GetComponent<Renderer>().material.color = colorRed;
            }
            else if (i==1)
            {
                buttons[1].gameObject.GetComponent<Renderer>().material.color = colorBlue;
            }
            else if (i == 2)
            {
                buttons[2].gameObject.GetComponent<Renderer>().material.color = colorgreen;
            }

            else if (i == 3)
            {
                buttons[3].gameObject.GetComponent<Renderer>().material.color = coloryellow;
            }
            else if(i==4)
        {
            whiteButton.gameObject.GetComponent<Renderer>().material.color = colorWhite;
        }
            //buttons[i].GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(sequenceDelayPressed);
        
    }
}
