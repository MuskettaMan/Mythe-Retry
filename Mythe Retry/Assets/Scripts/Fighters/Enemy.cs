﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : Fighter {
    #region Public Fields
    public static Action Died;
    public static Action<float> Attacking;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    protected virtual new void Start() {
        maxHealth = 30;
        base.Start();

        Player.Attacking += OnGettingAttacked;
        
    }

    void Update() {
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Attack(float damage) {
        Attacking?.Invoke(damage);
    }

    private void OnGettingAttacked(float damage) {
        currentHealth -= damage;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Enemy health is now: " + currentHealth);
        if(currentHealth == 0) {
            Died?.Invoke();
        } else {
            Attack(10); // Test value for damage
        }
    }
    #endregion
}