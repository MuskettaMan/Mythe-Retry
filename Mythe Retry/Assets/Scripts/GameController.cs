﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    #region Public Fields
    public WorldEnemy encounteredEnemy = null;
    #endregion

    #region Private Fields
    private GameObject[] runes;
    private Transform runesParent;
    private string runeTag = "Bubble";
    private SlotMaster slotMaster;
    private RuneInventory runeInventory;
    private CombatTimer combatTimer;
    private Enemy enemy;
    private Player player;
    [SerializeField] private CameraSwitcher cameraSwitcher;
    #endregion

    #region Unity Methods
    void Start() {
        runes = GameObject.FindGameObjectsWithTag(runeTag);
        runesParent = GameObject.Find("Runes").transform;
        SlotMaster.RunesAvailable += OnRunesAvailable;
        Player.TookDamage += OnPlayerTookDamage;
        slotMaster = GameObject.Find("Slots").GetComponent<SlotMaster>();
        combatTimer = GameObject.Find("Timer").GetComponent<CombatTimer>();
        runeInventory = FindObjectOfType<RuneInventory>();
        enemy = FindObjectOfType<Enemy>();
        player = FindObjectOfType<Player>();
        Player.Died += OnPlayerDied;
        Enemy.Died += OnEnemyDied;
    }

    void Update() {
    }
    #endregion

    #region Public Methods
    public void ResetBattle(WorldEnemy worldEnemy) {
        encounteredEnemy = worldEnemy;
        if(encounteredEnemy == null) {
            EndBattle(false);
        } else {
            enemy.SetEnemyGraphic(worldEnemy.sprite, worldEnemy.animatorController);
            enemy.sprite = worldEnemy.sprite;
            enemy.animatorController = worldEnemy.animatorController;
            enemy.SetMaxHealth(worldEnemy.maxHealth);
            enemy.damage = worldEnemy.damage;
            runeInventory.SpawnRunes();
            combatTimer.ResetTimer();
        }
    }

    public void EndBattle(bool won) {
        runeInventory.DestroyRunes();
        if(won) {
            cameraSwitcher.SwitchToWorldCamera();
            player.SetCurrentHealth(player.GetMaxHealth());
            Destroy(encounteredEnemy.gameObject);
        }
    }
    #endregion

    #region Private Methods
    private void OnRunesAvailable(Rune[] runes) {
        foreach(GameObject rune in this.runes) {
            //rune.SetActive(false);
        }
    }

    private void OnPlayerTookDamage() {
        foreach(var slot in slotMaster.slots) {
            slot.RemoveRune();
        }

        combatTimer.ResetTimer();
    }

    private void OnPlayerDied() {
        EndBattle(false);
    }

    private void OnEnemyDied() {
        EndBattle(true);
    }
    #endregion
}
