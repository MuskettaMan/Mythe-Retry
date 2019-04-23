using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwitchToCombat : MonoBehaviour
{
    public Action<bool> InCombat;
    private bool _inCombat;
    public bool BattleOver = false;
    private bool BattleWon = false;
    

    public GameObject EnemySpawnLocation;
    public GameObject PlayerSpawnLocation;

    private GameObject Player;
    private GameObject tempPosPlayer;

    private GameObject Enemy;
    private GameObject tempPosEnemy;

    private void Start()
    {
        InCombat(false);
        Player = GameObject.FindWithTag("Player");
        Enemy = GameObject.FindWithTag("Enemy");

    }

    public void CombatPositionTransform()
    {
        //saving the player position before battle
        RememberLocation();

        _inCombat = true;

        InCombat(true);
        //transforming position of Player & Enemy
        TransformPosition();
        if (BattleOver)
        {
            BattleOverTransform();
        }
    }

    private void RememberLocation()
    {
        tempPosPlayer.transform.position = Player.transform.position;
        tempPosEnemy.transform.position = Enemy.transform.position;
    }
    private void TransformPosition()
    {
        if(_inCombat == true)
        {
            Player.transform.position = PlayerSpawnLocation.transform.position;
            Enemy.transform.position = EnemySpawnLocation.transform.position;
            Player.GetComponent<PlayerController>().moveSpeed = 0;

        }
    }
    private void BattleOverTransform()
    {
        Player.transform.position = tempPosPlayer.transform.position;
        Enemy.transform.position = tempPosEnemy.transform.position;
        if (BattleWon)
        {
            Enemy.SetActive(false);
        }

    }
}

