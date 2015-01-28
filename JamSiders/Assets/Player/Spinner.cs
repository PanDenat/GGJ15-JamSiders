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
	    rot += GetRotationFromKeyboard();
	    if (debug) { Debug.Log("Spinner TriggerAxis: " + rot);}
	    rigidbody.AddRelativeTorque(Vector3.up * rot * rotScale * -1);
	}

    private float GetRotationFromKeyboard()
    {
        if (Input.GetButton("SpinLeft")) return -1;
        if (Input.GetButton("SpinRight")) return 1;
        return 0;
    }
}
