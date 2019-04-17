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

    public float GetCurrentHealth() {
        return currentHealth;
    }
    #endregion

    #region Private Methods
    #endregion
}
