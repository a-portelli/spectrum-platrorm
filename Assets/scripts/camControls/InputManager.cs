using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    Orbit _orbit;
    public Vector2 input;
    public Vector3 Vec;  


    //test crap
    public Transform camPivot;
    public Transform cam;
    float heading = 0;

    //bools for guardrails
    bool isTooLow = false;

    // Start is called before the first frame update
    void Start()
    {
        _orbit = GetComponent<Orbit>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1f;
        
        //Debug.Log(cam.eulerAngles.x);
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow) || 
            Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
            {
                _orbit.MoveHorizontal(true);
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow) || 
            Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
            {
                _orbit.MoveHorizontal(false);
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.UpArrow) || 
            Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
            {
                if(cam.eulerAngles.x < 88)
                {
                    isTooLow = false;
                    _orbit.MoveVert(true);
                }
                else
                {
                    isTooLow = true;
                }
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow) || 
            Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
            {
                if(cam.eulerAngles.x > 2)
                {
                    isTooLow = false;
                    _orbit.MoveVert(false);
                }
                else 
                {
                    isTooLow = true;
                }
            }
        }
        else
        {
            input = transform.localPosition;
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector3 camF = cam.forward;
            Vector3 camR = cam.right;

            camF.y = 0;
            camR.y = 0;
            camF = camF.normalized;
            camR = camR.normalized;

            transform.localPosition += (camF * input.y + camR * input.x) * Time.deltaTime * 50;
        }
    }
}
