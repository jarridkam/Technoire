using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AssemblyCSharp.Assets.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public float smoothing;

        private void LateUpdate()
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            if (transform.position != target.position)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            }   
        
        }   
    }
}
