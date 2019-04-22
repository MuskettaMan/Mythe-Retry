using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    #region Public Fields
    public Enemy encounteredEnemy = null;
    #endregion

    #region Private Fields
    private GameObject[] runes;
    private Transform runesParent;
    private string runeTag = "Bubble";
    private SlotMaster slotMaster;
    private RuneInventory runeInventory;
    private CombatTimer combatTimer;
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
        Player.Died += OnPlayerDied;
        Enemy.Died += OnEnemyDied;

        ResetBattle(encounteredEnemy);
    }

    void Update() {

    }
    #endregion

    #region Public Methods
    public void ResetBattle(Enemy enemy) {
        encounteredEnemy = enemy;
        if(encounteredEnemy = null) {
            EndBattle(false);
        } else {
            runeInventory.SpawnRunes();
        }
    }

    public void EndBattle(bool won) {
        runeInventory.DestroyRunes();

        if(won) {

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
