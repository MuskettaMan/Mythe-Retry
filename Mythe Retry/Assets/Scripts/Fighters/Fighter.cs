using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Fighter : MonoBehaviour {
    #region Public Fields
    #endregion

    #region Private Fields
    protected float maxHealth;
    protected float currentHealth;
    #endregion

    #region Unity Methods
    protected virtual void Start() {
        currentHealth = maxHealth;
    }

    void Update() {

    }
    #endregion

    #region Public Methods
    public float GetMaxHealth() {
        return maxHealth;
    }

    public void SetMaxHealth(float _maxHealth) {
        maxHealth = (_maxHealth > 0) ? _maxHealth : 0.1f;
    }

    public float GetCurrentHealth() {
        return currentHealth;
    }

    public void SetCurrentHealth(float _currentHealth) {
        currentHealth = (_currentHealth < maxHealth) ? _currentHealth : maxHealth;
    }
    #endregion

    #region Private Methods
    #endregion
}
