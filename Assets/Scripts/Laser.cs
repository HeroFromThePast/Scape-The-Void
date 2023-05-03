using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Laser : MonoBehaviour
{
    [SerializeField] LineRenderer lr;
    [SerializeField] Transform startPoint;

    

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, startPoint.position);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.right, out hit))
        {

            LaserDetector laserhit = hit.collider.GetComponent<LaserDetector>();

            if (hit.collider.CompareTag("cube"))
            {               
                    laserhit.HitByRaycast();
                   
                lr.SetPosition(1, hit.point);
            }
            else if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
        }
        else lr.SetPosition(1, -transform.right * 5000);
    }
}
