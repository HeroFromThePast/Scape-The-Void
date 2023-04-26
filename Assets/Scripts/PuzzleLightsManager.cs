using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLightsManager : MonoBehaviour
{
    public GameObject ganaste;
    private int puntosGanados = 0;
    [SerializeField] private GameObject parte1;

    [SerializeField] private GameObject parte2;
    [SerializeField] private GameObject parte3;
    float tiempo;
    bool cicle1 = true;
    bool cicle1win = false;
    public float velocidadParte1;
    bool cambiocorrtinas = false;
    bool cicle2 = true;
    bool cicle2win = false;
    public float velocidadParte2;

    bool cicle3 = true;
    bool cicle3win = false;
    public float velocidadParte3;
    // Start is called before the first frame update
    void Start()
    {
        ganaste.SetActive(false);
    }

    private void FixedUpdate()

    {
    }
    // Update is called once per frame
    void Update()
    {

        tiempo += Time.deltaTime;
        if (puntosGanados == 0)
        {
            if (cicle1win == false)
            {
                if (cicle1 == true)
                {
                    if (cambiocorrtinas == false)
                    {
                        cambiocorrtinas = true;
                        StartCoroutine(parte1cicle());
                        StopCoroutine(parte1cicle());
                    }
                }
                else
                {
                    if (cambiocorrtinas == false)
                    {
                        cambiocorrtinas = true;
                        StartCoroutine(endcicle1());
                        StopCoroutine(endcicle1());
                    }
                }

            }
            else
            {
                if (cambiocorrtinas == false)
                {
                    cambiocorrtinas = true;
                    StopCoroutine(parte1cicle());
                    StopCoroutine(endcicle1());
                    StartCoroutine(wincicle1());
                    StopCoroutine(wincicle1());
                    puntosGanados++;
                }
            }



        }
        else if (puntosGanados == 1)
        {
            if (cicle2win == false)
            {
                if (cicle2 == true)
                {

                    if (cambiocorrtinas == false)
                    {
                        cambiocorrtinas = true;
                        StartCoroutine(parte2cicle());
                        StopCoroutine(parte2cicle());
                    }
                }
                else
                {
                    if (cambiocorrtinas == false)
                    {
                        cambiocorrtinas = true;
                        StartCoroutine(endcicle2());
                        StopCoroutine(endcicle2());
                    }

                }

            }
            else
            {
                if (cambiocorrtinas == false)
                {
                    cambiocorrtinas = true;
                    StopCoroutine(parte2cicle());
                    StopCoroutine(endcicle2());
                    StartCoroutine(wincicle2());
                    StopCoroutine(wincicle2());
                    puntosGanados++;
                }
            }



        }
        else if (puntosGanados == 2)
        {
            if (cicle3win == false)
            {
                if (cicle3 == true)
                {

                    if (cambiocorrtinas == false)
                    {
                        cambiocorrtinas = true;
                        StartCoroutine(parte3cicle());
                        StopCoroutine(parte3cicle());
                    }

                }
                else
                {
                    if (cambiocorrtinas == false)
                    {
                        cambiocorrtinas = true;
                        StartCoroutine(endcicle3());
                        StopCoroutine(endcicle3());
                    }


                }

            }
            else
            {
                if (cambiocorrtinas == false)
                {
                    cambiocorrtinas = true;
                    StopCoroutine(parte3cicle());
                    StopCoroutine(endcicle3());
                    StartCoroutine(wincicle3());
                    
                    puntosGanados++;
                }
            }





        }
        else
        {
            Ganaste();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (puntosGanados == 0)
            {
                if ((tiempo >= velocidadParte1 * 9 || tiempo <= velocidadParte1 * 10.5)|| (tiempo >= velocidadParte1 *21 || tiempo<=velocidadParte1 * 22.5))
                {
                    cicle1win = true;
                   
                }
            }
            if (puntosGanados == 1)
            {
                if ((tiempo >= velocidadParte2 * 11 || tiempo <= velocidadParte1 * 12.5)|| (tiempo >= velocidadParte2 * 19 || tiempo <= velocidadParte2 * 21.5))
                {
                    cicle2win = true;
                  
                }
            }

            if (puntosGanados == 2)
            {
                if ((tiempo >= velocidadParte3 * 13 || tiempo <= velocidadParte1 * 14.5) || (tiempo >= velocidadParte3 * 23 || tiempo <= velocidadParte3 * 24.5))
                {
                    cicle3win = true;

                }
            }

        }
       
    }

    private void Ganaste()
    {
        ganaste.SetActive(true);
    }

    public IEnumerator parte1cicle()
    {
        yield return new WaitForSeconds(velocidadParte1*10);
        bool cambio = true;
        for (int i = 0; i < parte1.transform.childCount &&  cambio==true; i++)
        {
            if (i == 3)
            {
                yield return new WaitForSeconds(velocidadParte1);
                parte1.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                parte1.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
          

                yield return new WaitForSeconds(velocidadParte1);
                if(cicle1win==true)
                {
                    cambio = false;
                }
            }
            else
            {
                yield return new WaitForSeconds(velocidadParte1);
                parte1.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                parte1.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                yield return new WaitForSeconds(velocidadParte1);
               
            }
        }
        yield return new WaitForSeconds(0.5f);
        cicle1 = false;
        cambiocorrtinas = false;
      
    }
    

   

    public IEnumerator endcicle1()
    {
        yield return new WaitForSeconds(1f);
        for (int i = parte1.transform.childCount-1; i >= 0; i--)
        {
            yield return new WaitForSeconds(velocidadParte1);
            parte1.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                parte1.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
                yield return new WaitForSeconds(velocidadParte1);
            
        }
        cicle1 = true;
        tiempo = 0;
        cambiocorrtinas = false;



    }
    public IEnumerator parte2cicle()

    {
        yield return StartCoroutine(wincicle1());
        yield return new WaitForSeconds(0.5f);
        bool cambio = true;
        for (int i = 0; i < parte2.transform.childCount && cambio == true; i++)
        {
            if (i == 4)
            {
                yield return new WaitForSeconds(velocidadParte2);
                parte2.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                parte2.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);


                yield return new WaitForSeconds(velocidadParte2);
                if (cicle2win == true)
                {
                    cambio = false;
                }
            }
            else
            {
                yield return new WaitForSeconds(velocidadParte2);
                parte2.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                parte2.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                yield return new WaitForSeconds(velocidadParte2);
                if (cicle2win == true)
                {
                    cambio = false;
                }
            }
        }
        yield return new WaitForSeconds(1f);
        cicle2 = false;
        cambiocorrtinas = false;

    }




    public IEnumerator endcicle2()
    {
        yield return new WaitForSeconds(1f);
        for (int i = parte2.transform.childCount - 1; i >= 0; i--)
        {
            yield return new WaitForSeconds(velocidadParte2);
            parte2.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte2.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            yield return new WaitForSeconds(velocidadParte2);

        }
        cicle2 = true;
        tiempo = 0;
        cambiocorrtinas = false;



    }

    public IEnumerator parte3cicle()

    {
        yield return StartCoroutine(wincicle2());
        yield return new WaitForSeconds(1f);
        bool cambio = true;
        for (int i = 0; i < parte3.transform.childCount && cambio == true; i++)
        {
            if (i == 5)
            {
                yield return new WaitForSeconds(velocidadParte3);
                parte3.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                parte3.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);


                yield return new WaitForSeconds(velocidadParte3);
                if (cicle3win == true)
                {
                    cambio = false;
                }
            }
            else
            {
                yield return new WaitForSeconds(velocidadParte3);
                parte3.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                parte3.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                yield return new WaitForSeconds(velocidadParte3);
                if (cicle3win == true)
                {
                    cambio = false;
                }
            }
        }
        
        cicle3 = false;
        cambiocorrtinas = false;
    }




    public IEnumerator endcicle3()
    {
        yield return new WaitForSeconds(1f);
        for (int i = parte3.transform.childCount - 1; i >= 0; i--)
        {
            yield return new WaitForSeconds(velocidadParte3);
            parte3.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte3.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            yield return new WaitForSeconds(velocidadParte3);

        }
        cicle3 = true;
        tiempo = 0;
        cambiocorrtinas = false;


    }

    public IEnumerator wincicle1()
    {

        for (int i = 0; i < parte1.transform.childCount; i++)
        {
            yield return new WaitForSeconds(0.1f);
            parte1.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte1.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
            yield return new WaitForSeconds(0.1f);

        }
        cambiocorrtinas = false;

    }
    public IEnumerator wincicle2()

    {

        yield return new WaitForSeconds((1 + velocidadParte2 * parte2.transform.childCount));

        for (int i = 0; i < parte2.transform.childCount; i++)
        {
            yield return new WaitForSeconds(0.1f);
            parte2.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte2.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
            yield return new WaitForSeconds(0.1f);

        }

        cambiocorrtinas = false;
    }

    public IEnumerator wincicle3()

    {

        yield return new WaitForSeconds( velocidadParte3 * parte3.transform.childCount*5); ;

        for (int i = 0; i < parte3.transform.childCount; i++)
        {
            yield return new WaitForSeconds(0.1f);
            parte3.transform.GetChild(i).GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            parte3.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
            yield return new WaitForSeconds(0.1f);

        }

        cambiocorrtinas = false;
    }

    public void oprimirboton()
    {
        if (puntosGanados == 0)
        {
            if ((tiempo >= velocidadParte1 * 9 || tiempo <= velocidadParte1 * 10.5) || (tiempo >= velocidadParte1 * 21 || tiempo <= velocidadParte1 * 22.5))
            {
                cicle1win = true;

            }
        }
        if (puntosGanados == 1)
        {
            if ((tiempo >= velocidadParte2 * 11 || tiempo <= velocidadParte1 * 12.5) || (tiempo >= velocidadParte2 * 19 || tiempo <= velocidadParte2 * 21.5))
            {
                cicle2win = true;

            }
        }

        if (puntosGanados == 2)
        {
            if ((tiempo >= velocidadParte3 * 13 || tiempo <= velocidadParte1 * 14.5) || (tiempo >= velocidadParte3 * 23 || tiempo <= velocidadParte3 * 24.5))
            {
                cicle3win = true;

            }
        }
    }

}
