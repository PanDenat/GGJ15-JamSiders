using UnityEngine;
using System.Collections;
using Assets.Physics;
using Assets.Player;

public class PlayerController : MonoBehaviour
{
    public float velocityScale = 1f;
    public float jumpVelocity = 5f;
	private float lastGroundTouchTime = 0;
	public float minJumpInterval = 2f;

	private CollisionChecker collisionChecker;
	private PadController padController;
	public static int players;
	private int playerId;
	// Use this for initialization

	void Start ()
	{
		playerId = players++;
		padController = GameObject.Find("ControllerObject").GetComponent<PadController>();
        collisionChecker = collisionChecker ?? GetComponent<CollisionChecker>() ?? gameObject.AddComponent<CollisionChecker>();
	}

	// Update is called once per frame

	void Update()
    {
        var xzV = GetDesiredXZVelocity();
        Vector3 yV;

        yV = IsJump() ? new Vector3(0, jumpVelocity, 0) : new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);

        var v = xzV + yV;

        GetComponent<Rigidbody>().velocity = v;

        UpdateRotation();
    }

	private Grabber grabber;

	private void UpdateRotation()
    {
        grabber = grabber ?? GetComponent<Grabber>();
        var xzVelocity = GetComponent<Rigidbody>().velocity;
        xzVelocity.y = 0;
        if (!grabber.IsHolding && xzVelocity != Vector3.zero)
        {

            GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(xzVelocity *-1);
        }
    }

	private bool IsJump()
    {
        //return Input.GetButtonDown("Jump") && collisionChecker.IsColliding;
		return false;
    }


	private Camera camera;

	private Vector3 GetDesiredXZVelocity()
    {
		var x = padController.getAnalog(playerId, ControllerAnalogs.LEFTX);
		var z = -padController.getAnalog(playerId, ControllerAnalogs.LEFTY);

        var xzV = new Vector3(x, 0, z);
        xzV = Vector3.ClampMagnitude(xzV, 1);

        camera = camera ?? FindObjectOfType<Camera>();
        var camEulerAngles = camera.transform.rotation.eulerAngles;
        camEulerAngles.x = 0;
        var camXZrot = Quaternion.Euler(camEulerAngles);
        xzV = camXZrot*xzV;

        return xzV * velocityScale;
    }
}

