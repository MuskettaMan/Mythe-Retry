using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SedTresholdNumber : MonoBehaviour
{
    public Action<int> _TID;

    public GameObject Treshold;
    public int TresholdID;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _TID(TresholdID);
        }
    }
}
