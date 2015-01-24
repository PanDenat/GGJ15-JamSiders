using UnityEngine;
using System.Collections;
using Assets.Physics;

public class PlayerController : MonoBehaviour
{
    public float velocityScale = 1f;
    public float jumpVelocity = 5f;
    private float lastGroundTouchTime = 0;
    public float minJumpInterval = 2f;

    private CollisionChecker collisionChecker;


	// Use this for initialization
	void Start ()
	{
        collisionChecker = collisionChecker ?? GetComponent<CollisionChecker>() ?? gameObject.AddComponent<CollisionChecker>();
	}
	
	// Update is called once per frame
    void Update()
    {

        var xzV = GetDesiredXZVelocity();
        Vector3 yV;

        yV = IsJump() ? new Vector3(0, jumpVelocity, 0) : new Vector3(0, rigidbody.velocity.y, 0);

        var v = xzV + yV;

        rigidbody.velocity = v;

    }

    private bool IsJump()
    {
        return Input.GetButtonDown("Jump") && collisionChecker.IsColliding;
    }

    private Vector3 GetDesiredXZVelocity()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var xzV = new Vector3(x, 0, z);
        xzV = Vector3.ClampMagnitude(xzV, 1);
        

        return xzV * velocityScale;
    }

    void OnCollisionStay()
    {
        //Debug.Log("CollisionStay", this);
        //lastGroundTouchTime = Time.time;
    }
}

