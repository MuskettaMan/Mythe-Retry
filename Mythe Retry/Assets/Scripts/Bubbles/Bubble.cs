using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class Bubble : MonoBehaviour {

    private Ray ray;

    public bool dragging {
        get; private set;
    }

    private Rigidbody rigidbody;
    private SpriteRenderer spriteRenderer;
    private float _maxSpeed = 20;

    [SerializeField] private Color startColor;
    [SerializeField] private Color dragColor;
    [SerializeField] private Color interactableColor;

    [SerializeField] private Target _currentTarget;
   private MouseInput mouseInput;

    public event Action Arrived;
    public float _arrivalDistance = 0.5f;

    public bool interactable = true;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        mouseInput = FindObjectOfType<MouseInput>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.drag = 0.9f;

        spriteRenderer.color = startColor;

        SetTarget(_currentTarget);
    }

    private void Update() {
        Movement();

        if(mouseInput.GetClickedObject() != null) {
            if(mouseInput.GetClickedObject().GetInstanceID() == gameObject.GetInstanceID() && interactable) {
                dragging = true;
                SetTarget(mouseInput.GetMouseTarget());
            }
        }

        if(mouseInput.LeftMouseButtonReleased()) {
            dragging = false;
            SetTarget(GetComponent<Wanderer>().target.GetComponent<Target>());
        }

        if(dragging) {
            spriteRenderer.color = dragColor;
        } else if (!interactable) {
            spriteRenderer.color = interactableColor;
        } else {
            spriteRenderer.color = startColor;
        }
    }

    private void Movement() {
        if(_currentTarget == null) {
            return;
        }

        var desiredStep = _currentTarget.GetPosition() - transform.position;

        desiredStep.Normalize();

        var desiredVelocity = desiredStep * _maxSpeed;
        var steeringForce = desiredVelocity - rigidbody.velocity;
        rigidbody.velocity += steeringForce / rigidbody.mass;

        transform.position += rigidbody.velocity * Time.deltaTime;

        if(Vector3.Distance(_currentTarget.GetPosition(), transform.position) < _arrivalDistance) {
            if(Arrived != null) {
                Arrived();
            }
        }
    }

    public void SetTarget(Target target) {
        _currentTarget = target;
    }

    private void OnDisable() {
        spriteRenderer.color = startColor;
    }

}
