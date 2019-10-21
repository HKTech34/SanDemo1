using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Transform car;
    public float smoothness=0.2f;
    public Vector3 offset;
    
    void FixedUpdate()
    {
        Vector3 movPos = car.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, movPos, smoothness);
        transform.position = smoothPos;

        transform.LookAt(car);
    }
}
