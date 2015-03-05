using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;

namespace Assets.NavMesh
{
    class WalkingController : MonoBehaviour
    {
        private Animator animator;
        public float speedScale;

        void Start()
        {
            animator = GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("No animator");
            }
        }

        void Update()
        {
            animator.speed = transform.parent.GetComponent<Rigidbody>().velocity.magnitude*speedScale;
        }
    }
}
