using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEnemy : MonoBehaviour {

    public Sprite sprite;
    public RuntimeAnimatorController animatorController;

    public float maxHealth;
    public float damage;

    private GameController gameController;

    private void Start() {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "WorldPlayer") {
            gameController.ResetBattle(gameObject.GetComponent<WorldEnemy>());
        }
    }

}
