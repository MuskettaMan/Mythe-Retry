using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour {
    #region Public Fields
    #endregion

    #region Private Fields
    [SerializeField] private Player player;
    [SerializeField] private Image healthBar;
    #endregion

    #region Unity Methods
    void Start() {

    }

    void Update() {
        healthBar.fillAmount = Map(player.GetCurrentHealth(), 0, player.GetMaxHealth(), 0, 1);
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    // Returns the value in the new range
    float Map(float value, float low1, float high1, float low2, float high2) {
        return Mathf.Clamp(low2 + (value - low1) * (high2 - low2) / (high1 - low1), low2, high2);
    }
    #endregion
}
