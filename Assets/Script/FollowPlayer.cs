using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	private Transform player;
	private Vector3 offsetPositon;
	private bool isRotating;

	public float distance = 25;
	public float scrollSpeed = 10;
	public float rotateSpeed = 2;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		transform.LookAt (player.position);
		offsetPositon = transform.position - player.position;
		//初始化
		distance = 25;
		scrollSpeed = 10;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = player.position + offsetPositon;
		//视野：旋转
		RotateView ();
		//视野：拉近拉远
		ScrollView ();
	}

	void ScrollView()
	{
		print(Input.GetAxis("Mouse ScrollWheel"));
		distance = offsetPositon.magnitude;
		distance += -Input.GetAxis ("Mouse ScrollWheel") * scrollSpeed;
		distance = Mathf.Clamp (distance, 10, 35);
		offsetPositon = offsetPositon.normalized * distance;
	}

	void RotateView()
	{
		Input.GetAxis ("Mouse X");
		Input.GetAxis ("Mouse Y");
		if (Input.GetMouseButtonDown (1)) 
		{
			isRotating = true;
		}
		if (Input.GetMouseButtonUp (1)) 
		{
			isRotating = false;
		}
		if (isRotating) 
		{
			transform.RotateAround (player.position, Vector3.up, -rotateSpeed * Input.GetAxis ("Mouse X"));

			Vector3 originalPos = transform.position;
			Quaternion originalRotation = transform.rotation;
			transform.RotateAround (player.position, transform.right, -rotateSpeed * Input.GetAxis ("Mouse Y"));
			float x = transform.eulerAngles.x;
			if (x < 10 || x > 80) 
			{
				transform.position = originalPos;
				transform.rotation = originalRotation;
			}
		}
		offsetPositon = transform.position - player.position;
	}
}
