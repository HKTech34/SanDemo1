using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarControl : MonoBehaviour
{
    //Simple car control script for cars with using WheelCollider

    public float MotorForce, SteerForce;
    public WheelCollider FR_L_Wheel, FR_R_Wheel, RE_L_Wheel, RE_R_Wheel;

    //Valuables for calculating gas
    public float fullTankWL;
    public float fullTankTH;

    public float gassTankWL;
    public float gassTankTH;

    public Slider gasBar; 

    void Start()
    {
        gassTankWL = fullTankWL;
        gassTankTH = fullTankTH;


        if (gameObject.tag == "WLCar")
        {
            gasBar.value=CalculateGasWL();
        }
        if (gameObject.tag == "THCar")
        {
            gasBar.value=CalculateGasTH();
        }


    }
    void Update()
    {

        TankHandler();

    }
    public void TankHandler()
    {
        if (gameObject.tag == "WLCar")
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) { gassTankWL--; gasBar.value = CalculateGasWL();} // Each time W or S pressed car moves and Gas decreased

            float v = Input.GetAxis("Vertical") * -MotorForce;
            float h = Input.GetAxis("Horizontal") * SteerForce;

            RE_L_Wheel.motorTorque = v;
            RE_R_Wheel.motorTorque = v;

            FR_L_Wheel.steerAngle = h;
            FR_R_Wheel.steerAngle = h;
        }
        if (gameObject.tag == "THCar")
        {

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) { gassTankTH--; gasBar.value = CalculateGasTH(); } // Each time up or down pressed car moves and Gas decreased
            float v = Input.GetAxis("ArrowVertical") * -MotorForce;
            float h = Input.GetAxis("ArrowHorizontal") * SteerForce;

            RE_L_Wheel.motorTorque = v;
            RE_R_Wheel.motorTorque = v;

            FR_L_Wheel.steerAngle = h;
            FR_R_Wheel.steerAngle = h;
        }

    }
    float CalculateGasWL() // It's for slider in the UI it calculates remaning gas
    {
   
       return gassTankWL / fullTankWL;
        
    }
    float CalculateGasTH()
    {
        return gassTankTH / fullTankTH;
    }

}
