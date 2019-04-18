using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Rune : MonoBehaviour {
    #region Public Fields
    #endregion

    #region Private Fields
    public float minDamage;
    public float maxDamage;
    protected float mass;
    protected float cooldown;

    [SerializeField] protected Sprite sprite;
    protected ParticleSystem particleSystem;
    protected SpriteRenderer spriteRenderer;
    protected Rigidbody rigidbody;
    #endregion

    #region Unity Methods
    public virtual void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody>();
        spriteRenderer.sprite = sprite;
    }

    void Update() {
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    public void CoolDown() {
        StartCoroutine(WaitForCoolDown());
    }

    IEnumerator WaitForCoolDown() {
        var bubble = GetComponent<Bubble>();
        bubble.interactable = false;
        yield return new WaitForSeconds(cooldown);
        bubble.interactable = true;
    }
    #endregion
}
