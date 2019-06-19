using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Collider>().name == "Sphere")
        {
            // It is object 
            print("OnTriggerEnter");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.GetComponent<Collider>().name == "Sphere")
        {
            // It is object 
            print("OnTriggerExit");
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.GetComponent<Collider>().name == "Sphere")
        {
            // It is object 
            print("OnTriggerStay");
        }
    }

}
