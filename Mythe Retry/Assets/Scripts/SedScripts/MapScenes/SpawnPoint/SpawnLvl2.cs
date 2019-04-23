using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLvl2 : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform Player;

    void Start()
    {
        Player = spawnPoint;
    }

}
