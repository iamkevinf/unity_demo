using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {

	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButtonDown (0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit))
			{
				if(!hit.collider.name.Equals("Terrain"))
					return;
				 
				Vector3 point = hit.point;

				transform.LookAt(new Vector3(point.x, transform.position.y, point.z));
				agent.SetDestination(point);
			}
		}

		if (agent.remainingDistance == 0)  
		{  
			animation.Play("Idle");  
		}  
		else  
		{  
			animation.Play("Run");  
		}

	}
}
