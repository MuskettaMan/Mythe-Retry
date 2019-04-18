using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : CombinationAttack {
    #region Public Fields
    #endregion

    #region Private Fields
    private Player player;
    #endregion

    #region Unity Methods
    void Start() {
        SlotMaster.RunesAvailable += OnRunesAvailable;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        //Calculate the max and min damage for the attack
        minDamage = CalculateDamage(runes[0].minDamage, runes[1].minDamage);
        maxDamage = CalculateDamage(runes[0].maxDamage, runes[1].maxDamage);
    }

    void Update() {

    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void OnRunesAvailable(Rune[] runes) {
        // Slot combination matches that of the attack
        if(runes[0].GetType() == this.runes[0].GetType() && runes[1].GetType() == this.runes[1].GetType() ||
           runes[0].GetType() == this.runes[1].GetType() && runes[1].GetType() == this.runes[0].GetType()) {
            
            player.Attack(Random.Range(minDamage, maxDamage));
            runes[0].CoolDown();
            runes[1].CoolDown();
        }
    }
    #endregion
}
