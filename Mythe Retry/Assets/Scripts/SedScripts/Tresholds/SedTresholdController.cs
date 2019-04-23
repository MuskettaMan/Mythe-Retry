using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SedTresholdController : MonoBehaviour
{
    public Action<int> onPointAction;
    public Action FadeNow;
    
    public GameObject[] Treshold;
    public GameObject Player;

    [SerializeField]
    private GameObject[] SpawnPoint;

    [HideInInspector]
    public int _ID;

    public void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Treshold")
        {
     
            for(int i = 0; i < Treshold.Length; i++)
            {
                if (Treshold[i].GetComponent<SedTresholdNumber>().TresholdID == (i+1))
                {
                    //switch naar lvl 1_1
                    Treshold[i].GetComponent<SedTresholdNumber>().TresholdID = _ID;
                    onPointAction(_ID);
                    Player.transform.position = SpawnPoint[i].transform.position;
                    return;
                }
            }

            if(Treshold[0].GetComponent<SedTresholdNumber>().TresholdID == 1)
            {
                //switch naar lvl 1_1
                Treshold[0].GetComponent<SedTresholdNumber>().TresholdID = _ID;
                onPointAction(_ID);
                Player.transform.position = SpawnPoint[0].transform.position;
                return;
            }
            if(Treshold[1].GetComponent<SedTresholdNumber>().TresholdID == 2) 
            {
                //switch naar lvl 2
                Treshold[1].GetComponent<SedTresholdNumber>().TresholdID = _ID;
                onPointAction(_ID);
                Player.transform.position = SpawnPoint[1].transform.position;
                return;
            } 
            if (Treshold[2].GetComponent<SedTresholdNumber>().TresholdID == 3) 
            {
                //switch naar lvl3
                Treshold[2].GetComponent<SedTresholdNumber>().TresholdID = _ID;
                onPointAction(_ID);
                Player.transform.position = SpawnPoint[2].transform.position;
                return;
            }
        }
    }
    
}
