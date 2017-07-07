using UnityEngine;
using System.Collections;

public class PlayerDirection : MonoBehaviour {

	public GameObject effect_click_prefab;
	public Vector3 targetPositon = Vector3.zero;
	private bool isMoving = false;

	void Start()
	{
		targetPositon = transform.position;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
			bool isCollider = Physics.Raycast (ray, out hitInfo);
			if (isCollider && hitInfo.collider.tag == Tags.ground) 
			{
				isMoving = true;
				ShowClickEffect (hitInfo.point);
				LookAtTarget (hitInfo.point);
			}
		}
		if (Input.GetMouseButtonUp (0)) 
		{
			isMoving = false;
		}
		if (isMoving) 
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo;
			bool isCollider = Physics.Raycast (ray, out hitInfo);
			if (isCollider && hitInfo.collider.tag == Tags.ground) 
			{
				LookAtTarget (hitInfo.point);
			}
		}

	}

	//实例化：点击效果
	void ShowClickEffect(Vector3 hitPoint)
	{
		hitPoint = new Vector3 (hitPoint.x, hitPoint.y + 0.2f, hitPoint.z);
		GameObject.Instantiate (effect_click_prefab, hitPoint, Quaternion.identity);
	}
	//
	void LookAtTarget(Vector3 hitPoint)
	{
		targetPositon = hitPoint;
		targetPositon = new Vector3 (targetPositon.x, targetPositon.y, targetPositon.z);
		this.transform.LookAt (targetPositon);
	}
}
