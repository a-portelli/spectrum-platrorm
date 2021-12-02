using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraUI : MonoBehaviour
{

    //reference leftUI script for toggle information
    public leftUI _leftUI;

    //public button text
    public Text buttonText; 

    //global int to remember what the last camera used was
    public static int lastCam;

    //global bool
    public bool buttonIsClicked = false;

    public bool buttonUsed = false;

    //global cameras
    public GameObject isoCam;
    public GameObject birdCam;
    public GameObject groundCam;

    //Node cameras
    
    public GameObject cameraA;
    public GameObject cameraB;
    public GameObject cameraC;
    public GameObject cameraD;

    // Start is called before the first frame update
    public void turnIsoOn()
    {
        isoCam.SetActive(true);
        birdCam.SetActive(false);
        groundCam.SetActive(false);
        cameraA.SetActive(false);
        cameraB.SetActive(false);
        cameraC.SetActive(false);
        cameraD.SetActive(false);
        lastCam = 1;
    }

    public void turnBirdOn()
    {
        isoCam.SetActive(false);
        birdCam.SetActive(true);
        groundCam.SetActive(false);
        cameraA.SetActive(false);
        cameraB.SetActive(false);
        cameraC.SetActive(false);
        cameraD.SetActive(false);
        lastCam = 2;
    }

    public void turnGroundOn()
    {
        isoCam.SetActive(false);
        birdCam.SetActive(false);
        groundCam.SetActive(true);
        cameraA.SetActive(false);
        cameraB.SetActive(false);
        cameraC.SetActive(false);
        cameraD.SetActive(false);
        lastCam = 3;
    }

    public void buttonClick()
    {
        buttonIsClicked = !buttonIsClicked;

        if(buttonIsClicked == true)
        {
            buttonText.text = "Turn Off Node View";
        }
        else
        {
            buttonText.text = "Click To Snap Camera To Node";

            Debug.Log(lastCam);

            if(lastCam == 1)
            {
                turnIsoOn();
            }
            else if (lastCam == 2)
            {
                turnBirdOn();
            }
            else
            {
                turnGroundOn();
            }
        }
    }

    void Update() {
        if(buttonIsClicked == true && _leftUI.toggleA.isOn == true)
        {
            isoCam.SetActive(false);
            birdCam.SetActive(false);
            groundCam.SetActive(false);
            cameraA.SetActive(true);
            cameraB.SetActive(false);
            cameraC.SetActive(false);
            cameraD.SetActive(false);
        }
        else if(buttonIsClicked == true && _leftUI.toggleB.isOn == true)
        {
            isoCam.SetActive(false);
            birdCam.SetActive(false);
            groundCam.SetActive(false);
            cameraA.SetActive(false);
            cameraB.SetActive(true);
            cameraC.SetActive(false);
            cameraD.SetActive(false);
        }
        else if(buttonIsClicked == true && _leftUI.toggleC.isOn == true)
        {
            isoCam.SetActive(false);
            birdCam.SetActive(false);
            groundCam.SetActive(false);
            cameraA.SetActive(false);
            cameraB.SetActive(false);
            cameraC.SetActive(true);
            cameraD.SetActive(false);
        }
        else if(buttonIsClicked == true && _leftUI.toggleD.isOn == true)
        {
            isoCam.SetActive(false);
            birdCam.SetActive(false);
            groundCam.SetActive(false);
            cameraA.SetActive(false);
            cameraB.SetActive(false);
            cameraC.SetActive(false);
            cameraD.SetActive(true);
        }
    }
}
