using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour
{
    public bool debug;
    public float rotScale = 1;
    public float maxRotation = 5;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
        rigidbody.maxAngularVelocity = maxRotation;

	    var rot = Input.GetAxis("TriggerAxis");
	    if (debug) { Debug.Log("Spinner TriggerAxis: " + rot);}
	    rigidbody.AddRelativeTorque(Vector3.up * rot * rotScale * -1);
	}
}
