using System;
using System.Linq;
using UnityEngine;


public class Walker : MonoBehaviour
{

	[SerializeField]
	private Transform destination;
	private NavMeshPath path;
	public float Speed;

	void Awake()
	{
		path = new NavMeshPath();
	}
	public void Update()
	{
		if (destination != null)
		{
			if ((Vector3.Distance(transform.position, destination.position) > 1f))
			{
				if (NavMesh.CalculatePath(transform.position, destination.position, -1, path))
				{
					if (path.corners.Length > 1)
						rigidbody.velocity = ((path.corners[1] - transform.position)).normalized * Speed;
				}
				else
				{
					var a = GameObject.FindGameObjectsWithTag("Kulka").ToArray();
					SetDestination(a[UnityEngine.Random.Range(0, a.Length - 1)].transform);
				}
			}
		}
		else
		{
			var a = GameObject.FindGameObjectsWithTag("Kulka").ToArray();
			SetDestination(a[UnityEngine.Random.Range(0, a.Length - 1)].transform);
		}
	}

	public void SetDestination(Transform destination)
	{
		this.destination = destination;
	}
}
