using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta classe implementa um raycast com linerenderer

public class MyRaycast : MonoBehaviour {

    private GameObject go_linerenderer;
    private LineRenderer linerenderer;
    private Renderer rendline;

    // Use this for initialization
    void Awake () {
        go_linerenderer = new GameObject("ray_"+gameObject.name);
        go_linerenderer.transform.position = transform.position;
        linerenderer = go_linerenderer.AddComponent<LineRenderer>();
        linerenderer.startWidth = .03f;
        linerenderer.endWidth = .03f;
        rendline = linerenderer.GetComponent<Renderer>();
        rendline.material.color = Color.black;
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        if( Physics.Raycast(transform.position, transform.forward, out hit) )
        {
            //Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            rendline.material.color = Color.red;
            linerenderer.SetPosition(0, transform.position);
            linerenderer.SetPosition(1, hit.point);
        }
        else
        {
            //Debug.DrawRay(transform.position, transform.forward * 100, Color.green);
            rendline.material.color = Color.black;
            linerenderer.SetPosition(0, transform.position);
            linerenderer.SetPosition(1, transform.forward * 100);
        }
    }
}
