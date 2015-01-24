using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Physics
{
    class CollisionChecker : MonoBehaviour
    {
        public bool debug;
        private int collisionCount = 0;

        public bool IsColliding { get { return collisionCount > 0; } }

        void OnCollisionEnter()
        {
            if (debug) { Debug.Log("OnCollisionEnter, collisions: " + collisionCount, this); }
            collisionCount++;
        }

        void OnCollisionExit()
        {
            if (debug) { Debug.Log("OnCollisionLeave, collisions: " + collisionCount, this);}
            collisionCount--;
        }

    }
}
