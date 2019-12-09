using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class PlaneUsageExample : MonoBehaviour {

    public PhysicMaterial mat;
    public GameObject source;
    public Material crossMat;
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
            GameObject.Find("Upper_Hull").tag = "Obj";
            GameObject.Find("Lower_Hull").tag = "Obj";
            GameObject.Find("Upper_Hull").AddComponent<Rigidbody>();
            GameObject.Find("Lower_Hull").AddComponent<Rigidbody>();
            MeshCollider Upper = GameObject.Find("Upper_Hull").GetComponent<MeshCollider>();
            Upper.convex = true;
            Upper.material = mat;

            MeshCollider Lower = GameObject.Find("Lower_Hull").GetComponent<MeshCollider>();
            Lower.convex = true;
            Lower.material = mat;

            GameObject.Find("Upper_Hull").GetComponent<Transform>().name = "Upper_Hull" + System.Convert.ToString(i);

            GameObject.Find("Lower_Hull").GetComponent<Transform>().name = "Lower_Hull" + System.Convert.ToString(i);
            source.SetActive(false);
        }
       
    }
   
}