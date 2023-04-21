using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsManager : MonoBehaviour
{
    public GameObject listaLuces;
    private bool On;
    // Start is called before the first frame update
    void Start()
    {
        On = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            On = !On;
            Debug.Log(On.ToString());
        }

      

        if(On==true)
        {
            Light light = new Light();
            for(int i=0;i<listaLuces.transform.childCount;i++)
            {
                light = listaLuces.transform.GetChild(i).GetChild(0).GetComponent<Light>();
                light.enabled = true;
            }
        }
        else
        {
            Light light = new Light();
            for (int i = 0; i < listaLuces.transform.childCount; i++)
            {
                light = listaLuces.transform.GetChild(i).GetChild(0).GetComponent<Light>();
                light.enabled = false;
            }
        }
        
    }
}
