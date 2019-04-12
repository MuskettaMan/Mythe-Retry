using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Target : MonoBehaviour {
    #region Public Fields
    public bool showSprite = true;
    #endregion

    #region Private Fields
    private Vector3 position;
    private SpriteRenderer spriteRenderer;
    #endregion

    #region Unity Methods
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start() {
        SetPosition(new Vector3(transform.position.x, transform.position.y));
        spriteRenderer.enabled = showSprite;
    }

    void Update() {
        SetPosition(new Vector3(transform.position.x, transform.position.y));
    }

    private void OnDrawGizmos() {
        //Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere(transform.position, SteeringVehicle.GetArrivalDistance());
    }
    #endregion

    #region Public Methods
    public Vector3 GetPosition() {
        return position;
    }

    public void SetPosition(Vector3 _position) {
        position = _position;
        transform.position = position;
    }
    #endregion
}
#region Private Methods
#endregion
