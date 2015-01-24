using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.Camera.Editor
{
    [CustomEditor(typeof (CameraController))]
    internal class CameraControllerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var cameraController = (CameraController) target;

            if (GUILayout.Button("Update position"))
            {
                cameraController.offset = cameraController.transform.position - cameraController.target.transform.position;
                Vector3 lookAt = cameraController.target.position + cameraController.lookYoffset * Vector3.up;
                cameraController.transform.LookAt(lookAt);
            }
        }
    }
}
