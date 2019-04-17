using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Target))]
public class MouseFollower : MonoBehaviour {

    private Target target;
    [SerializeField] private MouseInput mouseInput;

    private void Awake() {
        target = GetComponent<Target>();
    }

    private void Update() {
        if(mouseInput.LeftMouseButtonHeld()) {
            target.SetPosition(mouseInput.GetMousePosition());
        }
    }

}
