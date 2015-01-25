using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Assets.Player;
using UnityEngine;

namespace Assets.Physics
{
    class BallSocketJoiner : MonoBehaviour
    {
        private CharacterJoint joint;
        private Grabber grabber;
        public Rigidbody ConnectedBody { get { return joint.connectedBody; } set { joint.connectedBody = value; } }

        void Start()
        {
            joint = gameObject.AddComponent<CharacterJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.anchor = GetComponent<GrabAnchor>().anchor.transform.localPosition;
            joint.connectedBody = grabber.rigidbody;
            joint.lowTwistLimit = new SoftJointLimit {limit = 0, bounciness = 0, spring = 0, damper = 0};
            joint.highTwistLimit = new SoftJointLimit {limit = 0, bounciness = 0, spring = 0, damper = 0};
            joint.swing1Limit = new SoftJointLimit() { limit = 90, bounciness = 0, spring = 0, damper = 0 };
            joint.swing1Limit = new SoftJointLimit() { limit = 90, bounciness = 0, spring = 0, damper = 0 };
            joint.axis = Vector3.up;
            joint.connectedAnchor = new Vector3(1.1f, -0.4f, .5f);
        }

        void OnDestroy()
        {
            Debug.Log("[BallSocketJoiner] Destroying joint");
            Destroy(joint);
        }

        public BallSocketJoiner Init(Grabber grabber)
        {
            this.grabber = grabber;
            return this;
        }
    }
}
