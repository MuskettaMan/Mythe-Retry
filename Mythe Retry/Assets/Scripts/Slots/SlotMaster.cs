using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SlotMaster : MonoBehaviour {

	[SerializeField]
	public List<Slot> slots = new List<Slot>(); // Slot array that holds two slots.

    [SerializeField] private CombatTimer combatTimer;

    public static Action SlotsFilled;
    [SerializeField] private PunchRune defaultPunchRune;

    public static Action<Rune[]> RunesAvailable;

    private Enemy enemy;

	private void Start() 
    {

        for(int i = 0; i < slots.Count; i++) {
            slots[i].RunePlaced += OnRunePlaced;
        }

        combatTimer.TimerEnded += OnTimerEnded;
        enemy = FindObjectOfType<Enemy>();
		
	}

	private void Update()
	{
        
	}

    public void OnRunePlaced(Rune rune) {
        bool runesFilled = true; // Temporary boolean

        for(int i = 0; i < slots.Count; i++) {
            if(slots[i].IsEmpty()) { // Checks if a slot is empty
                runesFilled = false; // If a slot is empty we know that not all runes are filled
            }
        }   
        
        if(runesFilled) { // If the boolean returns true, it didn't find a single empty slot, thus all slots are filled
            SlotsFilled();
        }

    }

    private void OnTimerEnded() {
        int indexSlotNotFilled = -1;
        int amountSlotsNotFilled = 0;

        for(int i = 0; i < slots.Count; i++) {
            if(slots[i].IsEmpty()) {
                indexSlotNotFilled = i;
                amountSlotsNotFilled++;
            }
        }

        // One Slot empty
        if(indexSlotNotFilled != -1 && amountSlotsNotFilled == 1) {
            slots[indexSlotNotFilled].InsertRune(defaultPunchRune); // Fill the empty slot with the default rune
        }

        if(amountSlotsNotFilled == 2) {
            enemy.OnGettingAttacked(0);
        }

        // All slots are filled
        if(amountSlotsNotFilled == 0) {
            Rune[] runes = { slots[0].GetRune(), slots[1].GetRune() };
            RunesAvailable?.Invoke(runes);
        }
    }
}
