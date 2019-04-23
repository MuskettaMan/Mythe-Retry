using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayerAnimationHandler : MonoBehaviour {
    #region Public Fields
    #endregion

    #region Private Fields
    private Animator animator;
    #endregion

    #region Unity Methods
    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {

    }
    #endregion

    #region Public Methods
    public void PunchAnimation() {
        animator.SetTrigger("Punch");
    }

    public AnimatorStateInfo GetCurrentStateInfo() {
        return animator.GetCurrentAnimatorStateInfo(0);
    }
    #endregion

    #region Private Methods
    #endregion
}
