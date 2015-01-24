using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class NavigationManager : MonoBehaviour
{

	public static NavigationManager instance;
	public List<string> Tags;
	[SerializeField]
	private Dictionary<string, List<Transform>> Transforms;
	void Awake()
	{
		if (instance != null)
			Destroy(instance);
		instance = this;
		Transforms = new Dictionary<string, List<Transform>>();
	}

	void Start()
	{
		foreach (var tag in Tags)
		{
			Transforms.Add(tag, GameObject.FindGameObjectsWithTag(tag).Select(a => a.transform).ToList());
		}
	}

	public Transform GetDestination(string tag, Transform origin)
	{
		if (Transforms.ContainsKey(tag) && Transforms[tag].Count > 0)
		{
			return Compute(Transforms[tag], origin);
		}
		Debug.LogWarning("Cant get destination");
		return null;
	}
	public List<Transform> GetClosestDestinations(string tag, Transform origin)
	{
		if (Transforms.ContainsKey(tag) && Transforms[tag].Count > 0)
		{
			return Transforms[tag].OrderBy(a => Vector3.Distance(a.transform.position, origin.transform.position)).ToList();
		}
		Debug.LogWarning("Cant get destination");
		return null;
	}
	private Transform Compute(List<Transform> transforms, Transform origin)
	{
		var lenght = transforms.Sum(a => 1 / Vector3.Distance(a.transform.position, origin.transform.position)); //dlugosc all
		var randomed = UnityEngine.Random.Range(0, lenght);
		Single asd = 0;
		var tempPath = new NavMeshPath();
		foreach (Transform transform in transforms)
		{
			if (NavMesh.CalculatePath(origin.position, transform.position, -1, tempPath))
			{
				var pathDistance = 1/PathDistance(tempPath);
				if (asd < randomed && randomed < asd + pathDistance)
					return transform;
				else
					asd += pathDistance;
			}
		}
		Debug.LogWarning("Cant get destination");
		return null;
	}

	Single PathDistance(NavMeshPath path)
	{
		Vector3 previousCorner = path.corners[0];
		float lengthSoFar = 0.0F;
		int i = 1;
		while (i < path.corners.Length)
		{
			Vector3 currentCorner = path.corners[i];
			lengthSoFar += Vector3.Distance(previousCorner, currentCorner);
			previousCorner = currentCorner;
			i++;
		}
		return lengthSoFar;
	}
}
