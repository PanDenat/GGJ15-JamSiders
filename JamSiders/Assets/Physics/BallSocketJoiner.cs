using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;

namespace Assets.Physics
{
    class BallSocketJoiner : MonoBehaviour
    {
        private CharacterJoint joint;
        public Rigidbody ConnectedBody { get { return joint.connectedBody; } set { joint.connectedBody = value; } }

        void Start()
        {
            joint = gameObject.AddComponent<CharacterJoint>();
            joint.lowTwistLimit = new SoftJointLimit {limit = 0, bounciness = 0, spring = 0, damper = 0};
            joint.highTwistLimit = new SoftJointLimit {limit = 0, bounciness = 0, spring = 0, damper = 0};
            joint.swing1Limit = new SoftJointLimit() { limit = 90, bounciness = 0, spring = 0, damper = 0 };
            joint.swing1Limit = new SoftJointLimit() { limit = 90, bounciness = 0, spring = 0, damper = 0 };
        }

        void OnDestroy()
        {
            Destroy(joint);
        }
    }
}
