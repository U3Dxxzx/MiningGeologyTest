using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BeginGame : MonoBehaviour {

	public float moveLength = 10f;
	public float moveTime = 2f;

	// Use this for initialization
	void Start () 
	{
		gameObject.transform.DOLocalMoveZ (moveLength, moveTime);
		//GameObject followPlayer = 
	}
	
	// Update is called once per frame
	void Update () 
	{
		moveTime -= Time.deltaTime;
		if (moveTime <= 0) 
		{
			Camera.main.GetComponent<FollowPlayer> ().enabled = true;
		}
	}
}
