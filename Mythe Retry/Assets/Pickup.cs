using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    [SerializeField] private GameObject rune;
    [SerializeField] private GameObject interactionGraphic;
    [SerializeField] private RuneInventory inventory;
    
    private GameObject clone;
    private SpriteRenderer spriteRenderer;

    private bool exited = false;

    private Color clear;

    private void Start() {
        clear = new Color(1, 1, 1, 0);
    }

    private void Update() {

        if(clone != null && Input.GetKeyDown(KeyCode.E)) {
            inventory.runeInventory.Add(rune);
            Destroy(clone);
            Destroy(gameObject);
        }

        if(spriteRenderer != null && spriteRenderer.color.a != 1 && !exited) {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.white, Time.deltaTime * 10);
        }

        if(exited && spriteRenderer != null) {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, clear, Time.deltaTime * 10);

            if(spriteRenderer.color.a < 0.1) {
                Destroy(clone);
                exited = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "WorldPlayer") {
            clone = Instantiate(interactionGraphic, transform);
            spriteRenderer = clone.GetComponent<SpriteRenderer>();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "WorldPlayer") {
            exited = true;
        }
    }

}
