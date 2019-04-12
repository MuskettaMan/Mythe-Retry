using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

    private Target mouseTarget;

    private void Start() {
        mouseTarget = FindObjectOfType<Target>();
    }

    private void Update() {
        if(LeftMouseButtonHeld()) {
            mouseTarget.SetPosition(GetMousePosition());
        }
    }

    public Vector3 GetMousePosition() {
        var mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    public bool LeftMouseButtonHeld() {
        return Input.GetMouseButton(0);
    }

    public bool LeftMouseButtonReleased() {
        return Input.GetMouseButtonUp(0);
    }

    public bool LeftMouseButtonDown() {
        return Input.GetMouseButtonDown(0);
    }

    public GameObject GetClickedObject() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(LeftMouseButtonDown()) {
            if(Physics.Raycast(ray, out hit)) {
                return hit.transform.gameObject;
            } else {
                return null;
            }
        } else {
            return null;
        }
    }

    public Target GetMouseTarget() {
        return mouseTarget;
    }

}
