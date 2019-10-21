using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TObjectController : MonoBehaviour
{
    // This script handles with Telehandler's object control, I wrote same piece of code for WheelLoader but it didn't work even thoug everything was okay.

    private bool body; // Bool for getting touch
    private bool keyPress; // Bool for keypress

    GameObject getCollidedObj;

    void Start()
    {
        body = false;
        keyPress = false;
    }

   
    void Update()
    {
        ButtonHandler();
    }
    void ButtonHandler()
    {
 
        if (Input.GetKey(KeyCode.Keypad7)) 
        {
            keyPress = true;
        }
        if (body)
        {
            if (Input.GetKey(KeyCode.Keypad9))
            {
                keyPress = false;
                Destroy(getCollidedObj.GetComponent<FixedJoint>());
                body = false;

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "redObj" || other.tag=="blueObj" || other.tag=="yellowObj" || other.tag=="greenObj") // If any of these object touches to collider
        {
            if (keyPress)
            {
                getCollidedObj = other.gameObject;
                other.gameObject.AddComponent<FixedJoint>(); // Add joint to object
                other.gameObject.GetComponent<FixedJoint>().connectedBody = gameObject.GetComponent<Rigidbody>(); // Connected body is telehandler
                body = true;
                keyPress = false;
            }
            
        }
        
    }
}
