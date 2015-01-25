﻿using System;
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

        public bool IsHolding { get { return grabbedJoiner != null; } }

        private void LetGo()
        {
            if (grabbedJoiner == null) { return; }
            Destroy(grabbedJoiner.GetComponent<CollisionHitter>());
            Destroy(grabbedJoiner);
            grabbedJoiner = null;
        }


        void Update()
        {
            if (Input.GetButtonDown("Grab"))
            {
                Grab();
            }

            if (Input.GetButtonDown("LetGo"))
            {
                Debug.Log("letting go");
                LetGo();
            }
        }

        private void Grab()
        {
            Debug.Log("grabbing");
            if (grabbedJoiner != null) { return; }
            var closest = UnityEngine.Physics.OverlapSphere(transform.position, maxGrabDistance).Where(col => col.GetComponent<GrabAnchor>() != null).GetClosest(transform.position);
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
