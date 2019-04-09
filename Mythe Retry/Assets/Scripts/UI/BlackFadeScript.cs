using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackFadeScript : MonoBehaviour
{
	private TresholdController _tc;
	private Animator anim;

	private void Start()
	{
		_tc = FindObjectOfType<TresholdController>();
		_tc.FadeNow += StartFade;
		anim = GetComponent<Animator>();
	}

	public void StartFade()
	{
		anim.SetTrigger("Fade");
	}

}
