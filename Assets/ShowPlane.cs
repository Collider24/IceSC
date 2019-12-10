using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ShowPlane : MonoBehaviour
{

    public void Show()
    {
        GameObject.Find("ZUBILO").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("ZUBILO").transform.GetChild(1).gameObject.SetActive(true);
    }

    public void Hide()
    {
        GameObject.Find("ZUBILO").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("ZUBILO").transform.GetChild(1).gameObject.SetActive(false);
    }
}
