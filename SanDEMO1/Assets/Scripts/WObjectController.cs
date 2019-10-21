using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WObjectController : MonoBehaviour
{
    private bool body;
    private bool keyPress;

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
    private void ButtonHandler()
    {
        if (Input.GetKey(KeyCode.V))
        {
            Debug.Log("button");
            keyPress = true;
        }
        if (body)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                keyPress = false;
                Destroy(getCollidedObj.GetComponent<FixedJoint>());
                body = false;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Help");
        if (other.tag == "redObj" || other.tag == "blueObj" || other.tag == "yellowObj")
        {
            if (keyPress)
            {
                Debug.Log("Lol");
                getCollidedObj = other.gameObject;
                other.gameObject.AddComponent<FixedJoint>();
                other.gameObject.GetComponent<FixedJoint>().connectedBody = gameObject.GetComponent<Rigidbody>();
                body = true;
                keyPress = false;
            }

        }
    }
}
