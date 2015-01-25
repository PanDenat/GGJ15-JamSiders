using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public static class MethodExtensions
    {
        public static T GetClosest<T>(this IEnumerable<T> objects, Vector3 point) where T : Component
        {
            float closestDistSq = Mathf.Infinity;
            T closest = null;
            foreach (var o in objects)
            {
                var distSq = (point - o.transform.position).sqrMagnitude;
                if (distSq < closestDistSq)
                {
                    closestDistSq = distSq;
                    closest = o;
                }
            }
            return closest;
        }
    }
}
