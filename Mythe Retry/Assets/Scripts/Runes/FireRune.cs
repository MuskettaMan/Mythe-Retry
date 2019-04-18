using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRune : Rune {
    #region Public Fields
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    protected virtual new void Start() {
        base.Start();

        minDamage = 10;
        maxDamage = 16;
        mass = 100;
        cooldown = 5;

        rigidbody.mass = mass;
    }

    void Update() {

    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
