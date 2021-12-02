using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainUserScript : MonoBehaviour
{
    public GameObject myUI;
    public bool status;
    // Start is called before the first frame update
    void Start()
    {
        status = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            if(status == true)
            {
                status = false;
                setUI(status);
            }
            else
            {
                status = true;
                setUI(status);
            }
        }
    }

    void setUI(bool newStatus)
    {
        if(status == true)
        {
            myUI.SetActive(true);
        }
        else
        {
            myUI.SetActive(false);
        }
    }
}
