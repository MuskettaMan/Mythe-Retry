using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SedLevelSwitch : MonoBehaviour
{
    public Action<int> OnTriggerAction;
    public Action<string> LevelName;

    public SedTresholdNumber TN;

    public GameObject Player;

    [SerializeField]
    private string[] MapNames;

    [SerializeField]
    private GameObject[] Tresholds;
    [SerializeField]
    private GameObject[] Spawnpoints;

    [HideInInspector]
    public int _ID;

    private void Start()
    {
        for(int i = 0; i < Tresholds.Length; i++)
        {
            Tresholds[i].name = MapNames[i];
            Debug.Log(Tresholds[i].name);
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Treshold")
        {
            
            
        }

    }
    

}
