using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneInventory : MonoBehaviour
{
	// References.
	private Pickup _pickup;

	// Inventory.
	public List<GameObject> inventory = new List<GameObject>();

    void Start()
    {
		_pickup = FindObjectOfType<Pickup>();
		_pickup.PickUpItem += AddItem;
    }

	private void AddItem(GameObject target) {
		inventory.Add(target);
	}
}
