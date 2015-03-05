using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    class KillZRespawner : MonoBehaviour
    {
        private Vector3 startPosition;
        void Start()
        {
            startPosition = transform.position;
        }

        void Update()
        {
            CheckKillZ();
        }

        private void CheckKillZ()
        {
            if (transform.position.y < -5) { StartCoroutine(Respawn()); }
        }

        private IEnumerator Respawn()
        {
            yield return new WaitForSeconds(3);
            GetComponent<Rigidbody>().position = startPosition;
        }
    }
}
