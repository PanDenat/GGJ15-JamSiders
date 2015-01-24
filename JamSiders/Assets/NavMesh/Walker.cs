﻿using System;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

[SelectionBase]
public class Walker : MonoBehaviour
{

	[SerializeField]
	public Transform destination;
	private NavMeshPath path;
	public float Speed;
	private new Transform transform;
	private const float reachDestinationDistance = 2.2f;
	public bool panicDestination;

	void Awake()
	{
		path = new NavMeshPath();
		transform = GetComponent<Transform>();
		Speed += UnityEngine.Random.Range(-1f, 1f);
	}
	public void Update()
	{
		if (destination != null)
		{
			if (Vector3.Distance(transform.position, destination.position) > reachDestinationDistance)
			{
				if (NavMesh.CalculatePath(transform.position, destination.position, -1, path))
				{
					if (path.corners.Length > 1)
						rigidbody.velocity = ((path.corners[1] - transform.position)).normalized * Speed;
				}
			}
			else
			{
				if (panicDestination) panicDestination = false;
			}
		}
	}

	public void SetDestination(Transform destination)
	{
		this.destination = destination;
	}
}
