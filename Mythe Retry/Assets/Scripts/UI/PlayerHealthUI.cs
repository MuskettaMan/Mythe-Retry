using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthUI : MonoBehaviour {
    #region Public Fields
    #endregion

    #region Private Fields
    private float health;
    private float maxHealth = 100;
    private Image healthBar;
    [SerializeField] private Image healthBarBackground;
    [SerializeField] private List<Image> borders = new List<Image>(); 
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private TextAsset playerJson;
    #endregion

    #region Unity Methods
    private void Awake() {
        healthBar = GetComponent<Image>();
    }

    void Start() {
        healthBar.fillMethod = Image.FillMethod.Horizontal; // Set fill method of the image to horizontal
        healthBar.fillOrigin = 0; // Fills image from the left
        
        // ToDo set health equal to the real Player Health
    }

    void Update() {
        health = Mathf.Clamp(health, 0, maxHealth);

        string text = Mathf.Round(health).ToString() + " / " + maxHealth;
        healthText.text = text;

        healthBar.fillAmount = Map(health, 0, 100, 0, 1); // Maps health from 0 and 100 to 0 and 1
        healthBar.color = Color.Lerp(Color.red, Color.green, Map(health, 0, maxHealth, 0, 1)); // Change the color of the healthbar based on the health amount
        healthBarBackground.color = Color.Lerp(Color.red, Color.green, Map(health, 0, maxHealth, 0, 1));

        for(int i = 0; i < borders.Count; i++) {
            borders[i].color = Color.Lerp(Color.red, Color.green, Map(health, 0, maxHealth, 0, 1));
        }
        
        /*Get reference to the color and change the alpha*/ {
            var color = healthBarBackground.color;
            color.a = 0.3f;
            healthBarBackground.color = color;
        }
        
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    // Returns the value in the new range
    float Map(float value, float low1, float high1, float low2, float high2) {
        return Mathf.Clamp(low2 + (value - low1) * (high2  - low2) / (high1 - low1), low2, high2);
    }
    #endregion
}
