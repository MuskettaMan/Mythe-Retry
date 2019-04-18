using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : Fighter {
    #region Public Fields
    public static Action Died;
    public static Action<float> Attacking;
    public static Action TookDamage;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    protected virtual new void Start() {
        maxHealth = 100;
        base.Start();

        Enemy.Attacking += OnGettingAttacked;
    }

    void Update() {
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    public void Attack(float damage) {
        Attacking?.Invoke(damage);
    }

    private void OnGettingAttacked(float damage) {
        currentHealth -= damage;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        TookDamage?.Invoke();
        if(currentHealth == 0) {
            Died?.Invoke();
        }
    }
    #endregion
}
