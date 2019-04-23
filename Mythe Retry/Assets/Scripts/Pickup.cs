using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//Geschreven door Erik, aangepast door Sed.
public class Pickup : MonoBehaviour
{
    // Interaction.
    public GameObject target;
    public Action Interacting;
    public Action<GameObject> PickUpItem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PickupInteraction.canInteract) Interact(target);
        }
    }

    private void Interact(GameObject target)
    {
        // Camera
        if (Interacting != null)
            Interacting();
        // Item
        if (PickUpItem != null)
            PickUpItem(target);
        Destroy(target, 0.3f);
    }
}
