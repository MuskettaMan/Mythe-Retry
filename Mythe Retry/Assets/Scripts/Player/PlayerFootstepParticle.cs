using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepParticle : MonoBehaviour
{
	private PlayerSounds _playerSounds;
	public GameObject dustPrefab;

	private void Start()
	{
		_playerSounds = FindObjectOfType<PlayerSounds>();
		_playerSounds.Walking += SpawnDust;
	}

	private void SpawnDust()
	{
		Instantiate(dustPrefab, transform);
	}
}
