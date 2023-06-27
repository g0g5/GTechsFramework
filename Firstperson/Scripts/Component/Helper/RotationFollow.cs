using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GTechs.Firstperson
{
    public class RotationFollow : MonoBehaviour
    {
        public Transform target;
        public float smoothTime = 0.3f;

        private float m_yVelocity = 0.0f;
        public enum RotationMode
        {
            Normal,
            Jelly,
            // Add more modes here
        }

        public bool isWorld = false;

        public RotationMode rotationMode = RotationMode.Normal;

        void Update()
        {
            float newYRotation = target.rotation.eulerAngles.y;

            switch (rotationMode)
            {
                case RotationMode.Normal:
                    transform.rotation = Quaternion.Euler(0f, newYRotation, 0f);
                    break;
                case RotationMode.Jelly:
                    newYRotation = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.y, newYRotation, ref m_yVelocity, smoothTime);
                    transform.rotation = Quaternion.Euler(0f, newYRotation, 0f);
                    break;
                    // Add more cases here
            }
        }
    }
}
