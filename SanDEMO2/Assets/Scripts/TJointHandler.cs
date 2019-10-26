using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TJointHandler : MonoBehaviour
{
    [SerializeField] GameObject tJoint1;
    [SerializeField] private float rotSpeed;
    Vector3 currentRot;
   
    [SerializeField] GameObject tJoint2;
    [SerializeField] private float movSpeed;

    private bool upLimControl;
    private bool downLimControl;

    void Start()
    {
        upLimControl = false;
        downLimControl = false;
    }

   
    void Update()
    {
        JointMov();
        ClampMov();
    }

    private void JointMov()
    {
        if (Input.GetKey(KeyCode.Keypad4))
        {
            tJoint1.transform.Rotate(Vector3.back * rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            tJoint1.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
        }

        if (!upLimControl)
        {
            if (Input.GetKey(KeyCode.Keypad8))
            {

                tJoint2.transform.Translate(Vector3.up * movSpeed * Time.deltaTime);
            }
        }

        if (!downLimControl)
        {
            if (Input.GetKey(KeyCode.Keypad2))
            {
                tJoint2.transform.Translate(Vector3.down * movSpeed * Time.deltaTime);
            }
        }
        
    }

    private void ClampMov()
    {
        if (gameObject.tag == "TJoint1")
        {
            currentRot = transform.rotation.eulerAngles;
            currentRot.z = Mathf.Clamp(currentRot.z, 0, 80);
            transform.rotation = Quaternion.Euler(currentRot);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UppLimit")
        {
            upLimControl = true;
        }
        if (other.tag == "DownLimit")
        {
            downLimControl = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "UppLimit")
        {
            upLimControl = false;
        }
        if (other.tag == "DownLimit")
        {
            downLimControl = false;
        }
    }
}
