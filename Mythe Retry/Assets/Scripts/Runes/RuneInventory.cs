using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneInventory : MonoBehaviour {
    #region Public Fields
    public List<GameObject> runeInventory = new List<GameObject>();
    public List<GameObject> spawnedRunes = new List<GameObject>();
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    void Start() {

    }

    void Update() {

    }
    #endregion

    #region Public Methods
    public void SpawnRunes() {
        // Instantiate all the runes in the inventory in the Runes parent
        for(int i = 0; i < runeInventory.Count; i++) {
            var clone = Instantiate(runeInventory[i], GameObject.Find("Runes").transform);
            clone.transform.position += new Vector3(-4 + i, 0, 0);
            spawnedRunes.Add(clone);
        }
    }

    public void DestroyRunes() {
        for(int i = 0; i < spawnedRunes.Count; i++) {
            Destroy(spawnedRunes[i]);
        }
    }
    #endregion

    #region Private Methods
    #endregion
}
