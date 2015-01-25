using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Physics
{
    class GrabAnchor : MonoBehaviour
    {
        public Transform anchor;
        void Awake()
        {
            anchor = anchor ?? transform.FindChild("anchor");
            if (anchor == null)
            {
                Debug.LogWarning("No anchor child in object with GrabAnchor");
                anchor = new GameObject().transform;
                anchor.transform.parent = transform;
                anchor.transform.localPosition = Vector3.zero;
            }
        }

    }
}
