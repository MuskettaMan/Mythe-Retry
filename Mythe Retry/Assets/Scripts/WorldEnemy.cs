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
        StartCoroutine(waitForTestBattle());
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            gameController.ResetBattle(this);
        }
    }

    private IEnumerator waitForTestBattle() {
        yield return new WaitForSeconds(3);

        gameController.ResetBattle(this);
    }

}
