using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammer : MonoBehaviour
{
    public PlaneUsageExample plane;
    int count = 0;
    System.Random rnd = new System.Random();
    int max;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hammer")
        {
            if (count == 0)
            {
                max = rnd.Next(1, 6);
            }
            if (count == max)
            {
                plane.Cut();
                count = 0;
            }
            else
            {
                count++;
            }
        }
    }
}
