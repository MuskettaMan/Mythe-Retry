using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombinationAttack : MonoBehaviour {
    #region Public Fields
    //public static int id;
    #endregion

    #region Private Fields
    protected float minDamage;
    protected float maxDamage;
    protected Player player;
    protected float waitDuration;
    [SerializeField] protected new ParticleSystem particleSystem;
    protected CombatPlayerAnimationHandler animationHandler;
    public Rune[] runes = new Rune[2];
    #endregion

    #region Unity Methods
    void Start() {

    }

    void Update() {

    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    protected float CalculateDamage(float a, float b) {
        return (a + b) / 2;
    }

    protected IEnumerator WaitForAttack(Rune[] _runes, float waitDuration) {
        yield return new WaitForSeconds(waitDuration);
        player.Attack(Random.Range(minDamage, maxDamage));
        _runes[0].CoolDown();
        _runes[1].CoolDown();
    }
    #endregion
}
