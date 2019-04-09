using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class TresholdController : MonoBehaviour
{
    public Action<int> onPointAction;
    public Action FadeNow;
    
    public GameObject[] Treshold;
    public GameObject Player;

    [SerializeField]
    private GameObject spawnPointLvl1_1;
    [SerializeField]
    private GameObject spawnPointLvl2;
    [SerializeField]
    private GameObject spawnPointLvl3;

    [HideInInspector]
    public int _ID;

    public void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Treshold")
        {
            
            if(Treshold[1].GetComponent<TresholdNumber>().TresholdID == 2) 
            {
                //switch naar lvl 2
                Treshold[1].GetComponent<TresholdNumber>().TresholdID = _ID;
                onPointAction(_ID);
                if (FadeNow != null) FadeNow();
                Player.transform.position = spawnPointLvl2.transform.position;
            } 
            else if (Treshold[2].GetComponent<TresholdNumber>().TresholdID == 3) 
            {
                //switch naar eindlevel
                Treshold[2].GetComponent<TresholdNumber>().TresholdID = _ID;
                onPointAction(_ID);
                if(FadeNow != null) FadeNow();
                Player.transform.position = spawnPointLvl3.transform.position;
            }
        }
    }
    
}
