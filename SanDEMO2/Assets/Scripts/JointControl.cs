using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointControl : MonoBehaviour
{
    // This script is for controlling WheelLoader's joints

    [SerializeField] private float rotSpeed;

    Vector3 currentRot;

    [SerializeField] GameObject joint1;
    [SerializeField] GameObject joint2;


    void Start()
    {
        
    }

    
    void Update()
    {
        
        JointMov();
        ClampMov();

    }

    private void JointMov() // It gets keypress and then moves the joints
    {

        if (Input.GetKey(KeyCode.Z))
        {
            joint1.transform.Rotate(Vector3.back * rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.X))
        {
            joint1.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            joint2.transform.Rotate(Vector3.back * rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            joint2.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
        }

    }
    private void ClampMov() // Restiricting the movements
    {
        if (gameObject.tag == "Joint1")
        {
            currentRot = transform.rotation.eulerAngles;
            currentRot.z = Mathf.Clamp(currentRot.z, 0, 80);
            transform.rotation = Quaternion.Euler(currentRot);
        }
        if (gameObject.tag == "Joint2")
        {
            currentRot = transform.rotation.eulerAngles;
            currentRot.z = Mathf.Clamp(currentRot.z, 0, 150);
            transform.rotation = Quaternion.Euler(currentRot);
        }



    }
}
