using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Bubble : MonoBehaviour {

    private Ray ray;

    public bool dragging {
        get; private set;
    }

    private Rigidbody rigidbody;
    private float _maxSpeed = 20;

    [SerializeField] private Target _currentTarget;
    [SerializeField] private MouseInput mouseInput;

    public event Action Arrived;
    public float _arrivalDistance = 0.5f;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        rigidbody.velocity = Vector3.zero;
        rigidbody.drag = 0.9f;

        SetTarget(_currentTarget);
    }

    private void Update() {
        Movement();

        if(mouseInput.GetClickedObject() != null) {
            if(mouseInput.GetClickedObject().tag == gameObject.tag) {
                dragging = true;
                SetTarget(mouseInput.GetMouseTarget());
            }
        }

        if(mouseInput.LeftMouseButtonReleased()) {
            dragging = false;
            SetTarget(GetComponent<Wanderer>().target.GetComponent<Target>());
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

}
