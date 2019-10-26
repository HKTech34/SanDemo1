using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectHandler : MonoBehaviour
{
    //WheelLoader had a problem about object control, That's why I put object control scripts to colored object for WheelLoader

    private bool bodyWL=false; // It gets the touch
    private bool keyPressWL; // It gets keypress

    void Start()
    {
        keyPressWL = false;
    }

    void Update()
    {
        ButtonHandler();
    }
    private void ButtonHandler()
    {
        if (GameObject.FindGameObjectWithTag("WLCar") != null)
        {
            if (Input.GetKey(KeyCode.C))
            {
                keyPressWL = true;
            }
            if (bodyWL)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    keyPressWL = false;
                    Destroy(gameObject.GetComponent<FixedJoint>());
                    bodyWL = false;

                }
            }
        }
      
    }
    private void OnTriggerExit(Collider other)
    {
        if (keyPressWL) // When space button pressed
        {
            gameObject.AddComponent<FixedJoint>(); // Add joint to colored object
            GetComponent<FixedJoint>().connectedBody = other.gameObject.GetComponent<Rigidbody>(); // attach to wheelloader
            bodyWL = true;
            keyPressWL = false;
        }

    }
   

}
