using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SedMapOnOff : MonoBehaviour
{
    private int Tint;
    public SedLevelSwitch _LS;

    public List<GameObject> mapList = new List<GameObject>();

    public void Start()
    {

        _LS.OnTriggerAction += MapSwitch;
        
    }

    

    private void MapSwitch(int id)
    {
        for (int i = 0; i < mapList.Count; i++)
        {
            mapList[i].SetActive(true);
        }
        mapList[id].SetActive(false);

    }
}
 