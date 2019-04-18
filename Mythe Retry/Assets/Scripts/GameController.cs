using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    #region Public Fields
    #endregion

    #region Private Fields
    private GameObject[] runes;
    private Transform runesParent;
    private string runeTag = "Bubble";
    private SlotMaster slotMaster;

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
    }

    void Update() {

    }
    #endregion

    #region Public Methods
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
    #endregion
}
