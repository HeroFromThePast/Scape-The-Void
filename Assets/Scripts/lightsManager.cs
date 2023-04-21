using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsManager : MonoBehaviour
{
    public List<GameObject> lampList;
    bool On = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            On = !On;
        }

        if(On==true)
        {
            Light light = new Light();
            foreach(GameObject i in lampList)
            {
                light = i.transform.GetChild(0).GetComponent<Light>();
                light.enabled = true;
            }
        }
        else
        {
            Light light = new Light();
            foreach (GameObject i in lampList)
            {
                light = i.transform.GetChild(0).GetComponent<Light>();
                light.enabled = false;
            }
        }
        
    }
}
