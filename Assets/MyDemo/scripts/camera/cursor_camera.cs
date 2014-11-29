using UnityEngine;
using System.Collections;

public class cursor_camera : MonoBehaviour {

	private GameObject target;
	private float rotX, rotY;
	private bool isActivated;

	public float zoomMin;
	public float zoomMax;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");

		Vector3 angles = transform.eulerAngles;
		rotX = angles.y;
		rotY = angles.x;
	}
	
	// Update is called once per frame
	void Update () {
		float offset = Input.GetAxis ("Mouse ScrollWheel");
		if (offset != 0)
			zoom (offset);

		if (Input.GetMouseButtonDown(1))
			isActivated = true;

		if (Input.GetMouseButtonUp(1))
			isActivated = false;

		if (isActivated)
			rotate ();
	}

	private void zoom(float offset)
	{
		Vector3 look = transform.forward;
		transform.position += look * offset;

		Vector3 origin = transform.position;
		Vector3 dir = transform.forward;

		Vector3 minPos = plainEquation (origin, dir, zoomMin);
		Vector3 maxPos = plainEquation (origin, dir, zoomMax);

		if (transform.position.y < zoomMin)
			transform.position = minPos;
		if (transform.position.y > zoomMax)
			transform.position = maxPos;
	}

	private void rotate()
	{
		float distance = Vector3.Distance (transform.position, target.transform.position);
		transform.position += transform.forward * distance;

		rotY -= Input.GetAxis("Mouse Y");
		rotX += Input.GetAxis("Mouse X");

		if (rotY < 4)
			rotY = 4;
		else if (rotY > 90)
			rotY = 90;

		Quaternion rotation = Quaternion.Euler(rotY, rotX, 0);
		transform.rotation = rotation;
		print (rotY.ToString() + ", " + rotX.ToString());

		transform.position -= transform.forward * distance;
	}

	private Vector3 plainEquation(Vector3 origin, Vector3 dir, float py)
	{
		return (py - origin.y) / dir.y * dir + origin;
	}
}
