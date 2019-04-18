using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneInventory : MonoBehaviour {
    #region Public Fields
    public List<GameObject> runeInventory = new List<GameObject>();
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    void Start() {
        // Instantiate all the runes in the inventory in the Runes parent
        for(int i = 0; i < runeInventory.Count; i++) {
            Instantiate(runeInventory[i], GameObject.Find("Runes").transform);
                
        }

    }

    void Update() {

    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
