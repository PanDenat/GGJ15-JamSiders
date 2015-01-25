using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Physics
{
    class CollisionHitter : MonoBehaviour
    {
        public float scale = 1f;
        public float upForce = 10f;

        void OnCollisionEnter(Collision collision)
        {
            float collisionSpeed = collision.relativeVelocity.magnitude;

            collision.collider.rigidbody.AddForceAtPosition((rigidbody.velocity - collision.relativeVelocity)*scale,
                collision.contacts.First().point);
            collision.collider.rigidbody.AddForce(Vector3.up*upForce * collisionSpeed);
        }
    }
}
