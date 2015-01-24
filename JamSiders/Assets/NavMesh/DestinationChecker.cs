using System;
using System.Linq;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class DestinationChecker : MonoBehaviour
{

	private Walker walker;
	public string Tag;

	private float targetDistance = 1f;
	void Start()
	{
		walker = GetComponent<Walker>();
	}
	void Update()
	{
		if (walker.destination==null)
			walker.SetDestination(NavigationManager.instance.GetDestination(Tag, walker.transform));

		if (walker.destination != null)
		{
			// If other occupy destination
			if (!walker.panicDestination && Physics.OverlapSphere(walker.destination.position, targetDistance)
				.Any(a => a.tag == "AI" && a.transform != transform))
				walker.SetDestination(NavigationManager.instance.GetDestination(Tag, transform));
			if (walker.destination == null && !walker.panicDestination)
			{
				var closest = NavigationManager.instance.GetClosestDestinations(Tag, transform);
				walker.destination = closest[Random.Range(0,(int)Math.Sqrt(closest.Count))];
				walker.panicDestination=true;
			}
		}
	}
	void OnDrawGizmos()
	{
		if (walker != null && walker.destination != null)
			Gizmos.DrawSphere(walker.destination.position, targetDistance);
	}
}
