using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomControl : MonoBehaviour
{
    public Camera cam;
    public int zoom = 1;
    public int normal = 60;
    float smooth  = 1;

    private bool isZoomed = false;

    void Update() {

        if(Input.mouseScrollDelta.y > 0)
        {
            Debug.Log(Input.mouseScrollDelta.y);
            GetComponent<Camera>().fieldOfView += 1;
        }
        if(Input.mouseScrollDelta.y < 0)
        {
            Debug.Log(Input.mouseScrollDelta.y);
            GetComponent<Camera>().fieldOfView -= 1;
        }
    }
}
