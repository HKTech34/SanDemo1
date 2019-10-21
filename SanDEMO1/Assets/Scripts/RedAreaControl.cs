﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAreaControl : MonoBehaviour
{
    //This script handles with colored areas, each time when you leave object, object count increases
    public FinishManager FinishMan;
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "redObj")
        {
            FinishMan.redObjCount++;
        }
    }
 


}
