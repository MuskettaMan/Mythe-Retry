using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackFadeScript : MonoBehaviour
{
	private Animator anim;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void StartFade()
	{
		anim.SetTrigger("Fade");
	}

}
