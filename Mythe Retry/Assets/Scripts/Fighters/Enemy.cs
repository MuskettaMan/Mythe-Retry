using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : Fighter {
    #region Public Fields
    public static Action Died;
    public static Action<float> Attacking;
    public Sprite sprite;
    public RuntimeAnimatorController animatorController;
    public float damage;
    #endregion

    #region Private Fields
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    #endregion

    #region Unity Methods
    protected virtual new void Start() {
        maxHealth = 30;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        base.Start();

        Player.Attacking += OnGettingAttacked;
        
    }

    void Update() {
    }
    #endregion

    #region Public Methods
    public void SetEnemyGraphic(Sprite _sprite, RuntimeAnimatorController _animatorController) {

        spriteRenderer.sprite = _sprite;
        animator.runtimeAnimatorController = _animatorController;
    }
    #endregion

    #region Private Methods
    public static void Attack(float damage) {
        Attacking?.Invoke(damage);
    }

    public void OnGettingAttacked(float damage) {
        currentHealth -= damage;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        if(currentHealth == 0) {
            Died?.Invoke();
        } else {
            StartCoroutine(WaitForAttack());// Test value for damage
        }
    }

    public virtual void SetMaxHealth(float health) {
        base.SetMaxHealth(health);
        currentHealth = maxHealth;
    }

    private IEnumerator WaitForAttack() {
        animator.SetTrigger("Punch");
        yield return new WaitForSeconds(3);
        Attack(10);
    }
    #endregion
}
