using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameTrigger : MonoBehaviour {
    public hammer ham;
    public PlaneUsageExample pl;
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Obj")
        {
            pl.name = other.gameObject.transform.name;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Obj")
            ham.count = 0;
    }
}