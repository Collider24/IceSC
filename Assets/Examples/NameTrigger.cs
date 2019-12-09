using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameTrigger : MonoBehaviour {

    public PlaneUsageExample pl;
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Obj")
        {
            //pl = GameObject.Find("SlicerPlane").GetComponent<PlaneUsageExample>();

            pl.name = other.gameObject.transform.name;
        }
    }
}