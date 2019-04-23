﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Geschreven door Erik, aangepast door Sed.
public class PickupInteraction : MonoBehaviour
{
    // Drag the button in inspector.
    public GameObject[] interactGO;
    public GameObject pickupGO;

    public static bool canInteract = false;
    public static bool isInteracting = false;

    // References.
    private Pickup _pickup;

    private void Start()
    {
        _pickup = FindObjectOfType<Pickup>();
        _pickup.PickUpItem += StopInteracting;

        for (int i = 0; i < interactGO.Length; i++)
        {
            interactGO[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (!canInteract) isInteracting = false;

        if (isInteracting)
        {
            interactGO[0].SetActive(false);
            interactGO[1].SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            interactGO[0].SetActive(true);
            canInteract = true;
            _pickup.target = pickupGO;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < interactGO.Length; i++) interactGO[i].SetActive(false);
            canInteract = false;
        }
    }

    private void StopInteracting(GameObject target)
    {
        Debug.Log("test");
    }
}