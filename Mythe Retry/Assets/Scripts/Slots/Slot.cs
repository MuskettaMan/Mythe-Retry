using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slot : MonoBehaviour {

	private Rune rune = null;

	public Action<Rune> RunePlaced;

    private string runeTag = "Bubble";

    public void InsertRune(Rune target) // Inserts slot in the slot array.
	{
        if(rune != null)
            return;

        if(target != null) {
            rune = target;
            rune.transform.SetParent(transform);

            rune.GetComponent<Wanderer>().enabled = false;
            rune.GetComponent<Bubble>().enabled = false;
            rune.GetComponent<Rigidbody>().velocity = Vector3.zero;
            rune.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            rune.GetComponent<SphereCollider>().enabled = false;
            rune.transform.rotation = Quaternion.identity;
            rune.transform.position = transform.position;
        }

		if (RunePlaced != null)
			RunePlaced(rune);
	}

    public void RemoveRune() {
        if(rune != null) {
            rune.transform.SetParent(GameObject.Find("Runes").transform);
            rune.GetComponent<SphereCollider>().enabled = true;
            rune.GetComponent<Wanderer>().enabled = true;
            rune.GetComponent<Bubble>().enabled = true;
            StartCoroutine(WaitForRuneToLeave());
        }
    }

    public bool IsEmpty() {
        return rune == null;
    }

    public Rune GetRune() {
        return rune;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == runeTag) {
            InsertRune(other.GetComponent<Rune>());
        }
    }

    IEnumerator WaitForRuneToLeave() {
        yield return new WaitForSeconds(2);
        rune = null;
    }

}
