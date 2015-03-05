using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Physics
{
    class CollisionHitter : MonoBehaviour
    {
        public float scale = 30f;
        public float upForce = 10f;

        void OnCollisionEnter(Collision collision)
        {
            float collisionSpeed = collision.relativeVelocity.magnitude;

            if (collision.collider.GetComponent<Rigidbody>() == null) return;

            collision.collider.GetComponent<Rigidbody>().AddForceAtPosition((GetComponent<Rigidbody>().velocity - collision.relativeVelocity)*scale,
                collision.contacts.First().point);
            collision.collider.GetComponent<Rigidbody>().AddForce(Vector3.up*upForce * collisionSpeed);
        }
    }
}
