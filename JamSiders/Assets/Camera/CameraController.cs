using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;

namespace Assets.Camera
{
    public class CameraController : MonoBehaviour
    {
        public Transform target;
        public float lookYoffset;
        public Vector3 offset;

        void Start()
        {
            if (target != null) { return; }
            target = FindObjectOfType<PlayerController>().transform;
        }

        void Update()
        {
            if (target == null) return;
            Vector3 position = target.position + offset;
            Vector3 lookAt = target.position + lookYoffset*Vector3.up;
            transform.position = position;
            transform.LookAt(lookAt);
        }
    }
}
