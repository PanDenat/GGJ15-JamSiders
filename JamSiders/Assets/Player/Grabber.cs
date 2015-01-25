using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Physics;
using UnityEngine;

namespace Assets.Player
{
    class Grabber : MonoBehaviour
    {
        public float maxGrabDistance = 3;

        private BallSocketJoiner _grabbed;

        private BallSocketJoiner grabbedJoiner
        {
            get { return _grabbed; }
            set
            {
                if (_grabbed != null && value != null)
                {
                    Debug.LogWarning("Grabbing with grabbed!", this);
                    LetGo();
                }
                _grabbed = value;
            }
        }

        private void LetGo()
        {
            Destroy(grabbedJoiner);
        }


        void Update()
        {
            if (Input.GetButtonDown("Grab"))
            {
                Grab();
            }
        }

        private void Grab()
        {
            var closest = UnityEngine.Physics.OverlapSphere(transform.position, maxGrabDistance).GetClosest(transform.position);
            if (closest != null)
            {
                var joiner = closest.gameObject.AddComponent<BallSocketJoiner>();
                joiner.ConnectedBody = rigidbody;
                grabbedJoiner = joiner;
            }
        }
    }
}
