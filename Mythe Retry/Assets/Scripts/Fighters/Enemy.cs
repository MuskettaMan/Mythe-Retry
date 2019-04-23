﻿using System.Collections;
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

        spriteRenderer.sprite = sprite;
        animator.runtimeAnimatorController = animatorController;
        base.Start();

        Player.Attacking += OnGettingAttacked;
        
    }

    void Update() {
    }
    #endregion

    #region Public Methods
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

    private IEnumerator WaitForAttack() {
        animator.SetTrigger("Punch");
        yield return new WaitForSeconds(3);
        Attack(10);
    }
    #endregion
}
