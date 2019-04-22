using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRune : Rune {
    #region Public Fields
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    protected virtual new void Start() {
        base.Start();

        minDamage = 11;
        maxDamage = 15;
        mass = 130;
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
