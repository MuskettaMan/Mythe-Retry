using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRune : Rune {
    #region Public Fields
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    protected virtual new void Start() {
        base.Start();

        minDamage = 8;
        maxDamage = 15;
        mass = 80;
        cooldown = 8;

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
