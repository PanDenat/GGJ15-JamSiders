using System;
using System.Collections;
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
	public float Acceleration;
	private new Transform transform;
	private const float reachDestinationDistance = 2.2f;
	public bool panicDestination;

	void Awake()
	{
		path = new NavMeshPath();
		transform = GetComponent<Transform>();
		Speed += UnityEngine.Random.Range(-1f, 1f);
	}

	public void FixedUpdate()
	{
	    UpdateRotation();
		if (destination != null)
		{
			if (Vector3.Distance(transform.position, destination.position) > reachDestinationDistance)
			{
				if (NavMesh.CalculatePath(transform.position, destination.position, -1, path))
				{
					if (path.corners.Length > 1)
					{
						if (rigidbody.velocity.magnitude<Speed)
							rigidbody.AddForce(((path.corners[1] - transform.position)).normalized * Acceleration);
					}
				}
			}
			else
			{
				if (panicDestination) panicDestination = false;
			}
		}
	}

    private void UpdateRotation()
    {
        var xzVelocity = rigidbody.velocity;
        xzVelocity.y = 0;
        if (xzVelocity != Vector3.zero)
        {
            rigidbody.rotation = Quaternion.LookRotation(xzVelocity * -1);
        }
    }

	public void SetDestination(Transform destination)
	{
		this.destination = destination;
	}
}
