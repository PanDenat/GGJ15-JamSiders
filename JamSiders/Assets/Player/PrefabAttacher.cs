using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Player
{
    class PrefabAttacher : MonoBehaviour
    {
        public GameObject[] prefabsToAttach;

        void Awake()
        {
            foreach (var prefab in prefabsToAttach)
            {
                var go = (GameObject)Instantiate(prefab);
                go.transform.parent = transform;
                go.transform.localPosition = prefab.transform.position;
            }
        }
    }
}
