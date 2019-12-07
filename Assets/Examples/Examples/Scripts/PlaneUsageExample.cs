using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class PlaneUsageExample : MonoBehaviour {

    public GameObject source;
    public Material crossMat;
    public bool recursiveSlice;
    public PlaneUsageExample plane;
    public string name;
    int i = 0;
    public void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
        {
            Cut();
        }
    }

    public SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null) {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
	}


	public void OnDrawGizmos() {
		EzySlice.Plane cuttingPlane = new EzySlice.Plane();


		cuttingPlane.Compute(transform);
        
		cuttingPlane.OnDebugDraw();
	}

    public void Cut()
    {
        source = GameObject.Find(name);

        SlicedHull hull = plane.SliceObject(source, crossMat);

        if (hull != null)
        {
            hull.CreateLowerHull(source, crossMat);
            hull.CreateUpperHull(source, crossMat);
            i++;

            GameObject.Find("Upper_Hull").AddComponent<MeshCollider>();
            GameObject.Find("Lower_Hull").AddComponent<MeshCollider>();
            GameObject.Find("Upper_Hull").AddComponent<NameTrigger>();
            GameObject.Find("Lower_Hull").AddComponent<NameTrigger>();
            MeshCollider Upper = GameObject.Find("Upper_Hull").GetComponent<MeshCollider>();
            Upper.convex = true;
            Upper.isTrigger = true;

            MeshCollider Lower = GameObject.Find("Lower_Hull").GetComponent<MeshCollider>();
            Lower.convex = true;
            Lower.isTrigger = true;

            GameObject.Find("Upper_Hull").GetComponent<Transform>().name = "Upper_Hull" + System.Convert.ToString(i);

            GameObject.Find("Lower_Hull").GetComponent<Transform>().name = "Lower_Hull" + System.Convert.ToString(i);
            source.SetActive(false);
        }
       
    }
   
}