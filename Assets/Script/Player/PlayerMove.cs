using UnityEngine;
using System.Collections;

public enum PlayerState{
	Moving,
	Idle,
	Attack
}

public class PlayerMove : MonoBehaviour {

	public float moveSpeed = 1f;
	public PlayerState state = PlayerState.Idle;
	private PlayerDirection playerDir;
	private CharacterController controller;

	// Use this for initialization
	void Start () 
	{
		playerDir = this.GetComponent<PlayerDirection> ();
		controller = this.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float distance = Vector3.Distance (playerDir.targetPositon, transform.position);
		if (distance > 0.1f) {
			state = PlayerState.Moving;
			controller.SimpleMove (transform.forward * moveSpeed);
		} 
		else 
		{
			state = PlayerState.Idle;
		}

	}
}
