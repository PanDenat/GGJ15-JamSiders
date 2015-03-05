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
        private PlayerController playerCtrl;

        protected void Start()
        {
            playerCtrl = GetComponent<PlayerController>();
        }

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

        public bool IsHolding { get { return grabbedJoiner != null; } }

        private void LetGo()
        {
            if (grabbedJoiner == null) { return; }
            Debug.Log("letting go");
            Destroy(grabbedJoiner.GetComponent<CollisionHitter>());
            Destroy(grabbedJoiner);
            grabbedJoiner = null;
        }


        void Update()
        {
            var pad = playerCtrl.padController;
            var padId = playerCtrl.playerId;
			if (pad.isPressed(padId, ControllerButtons.BUTX))
			{
				Grab();
			}

			if (pad.isPressed(padId, ControllerButtons.BUTB))
			{
				LetGo();
			}
        }

        private void Grab()
        {
            if (grabbedJoiner != null) { return; }
            Debug.Log("grabbing");
            var closest = UnityEngine.Physics.OverlapSphere(transform.position, maxGrabDistance).Where(col => col.attachedRigidbody != null && col.attachedRigidbody.GetComponent<GrabAnchor>() != null)
                .Select(col=> col.attachedRigidbody.GetComponent<GrabAnchor>()).GetClosest(transform.position);
            if (closest != null)
            {
                Debug.Log("targetfound");
                var joiner = closest.gameObject.AddComponent<BallSocketJoiner>().Init(this);
                closest.gameObject.AddComponent<CollisionHitter>();
                //joiner.ConnectedBody = rigidbody;
                grabbedJoiner = joiner;
            }
        }
    }
}
