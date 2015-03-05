using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour
{
    public bool debug;
    public float rotScale = 1;
    public float maxRotation = 5;
    private PlayerController playerCtrl;


    // Use this for initialization
	void Start ()
	{
	     playerCtrl = GetComponentInParent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        GetComponent<Rigidbody>().maxAngularVelocity = maxRotation;

	    var pad = playerCtrl.padController;
	    var padId = playerCtrl.playerId;

	    var rot = pad.getAnalog(padId, ControllerAnalogs.LEFTTRIGGER) - pad.getAnalog(padId, ControllerAnalogs.RIGHTTRIGGER); //Input.GetAxis("TriggerAxis");
		rot += GetRotationFromKeyboard();
		if (debug) { Debug.Log("Spinner TriggerAxis: " + rot);}
		GetComponent<Rigidbody>().AddRelativeTorque(Vector3.up * rot * rotScale * -1);
	}

    private float GetRotationFromKeyboard()
    {
		//if (Input.GetButton("SpinLeft")) return -1;
		//if (Input.GetButton("SpinRight")) return 1;
        return 0;
    }
}
