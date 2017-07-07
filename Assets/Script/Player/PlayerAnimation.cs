using UnityEngine;
using System.Collections;
using UnityEngine.Experimental;

public class PlayerAnimation : MonoBehaviour {

	private PlayerMove move;

	// Use this for initialization
	void Start () 
	{
		move = this.GetComponent<PlayerMove> ();
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		if (move.state == PlayerState.Moving) 
		{
			PlayAnim ("Sword-Run");
		} 
		else if (move.state == PlayerState.Idle) 
		{
			PlayAnim ("Sword-Idle");
		}
		else if (move.state == PlayerState.Attack) 
		{
			PlayAnim ("Sword-Attack1");
		}

	}

	void PlayAnim(string animName)
	{
		GetComponent<Animation>().CrossFade (animName);

	}
}
