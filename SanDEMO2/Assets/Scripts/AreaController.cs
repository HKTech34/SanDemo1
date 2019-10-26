using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AreaController : MonoBehaviour
{

    public FinishManager FinishMang;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == gameObject.tag)
        {
            FinishMang.count++;
        }
       
    }
}
