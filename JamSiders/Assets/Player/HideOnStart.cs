using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Player
{
    class HideOnStart : MonoBehaviour
    {
        public MeshRenderer[] renderersToDisable;

        void Start()
        {
            foreach (var c in renderersToDisable)
            {
                c.enabled = false;
            }
        }
    }
}
