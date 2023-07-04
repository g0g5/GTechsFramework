using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GTechs.Firstperson
{
    public class MouseViewLegacy : MonoBehaviour
    {
        //using unity's legacy input
        public float horizontalSpeed = 2.0f;
        public float verticalSpeed = 2.0f;
        public float minY = -60f;
        public float maxY = 80f;

        private float m_rotationY = 0f;

        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            var h = Input.GetAxis("Mouse X");
            var v = Input.GetAxis("Mouse Y");

            var rotationX = transform.localEulerAngles.y + horizontalSpeed * h;
            m_rotationY += verticalSpeed * v;
            m_rotationY = Mathf.Clamp(m_rotationY, minY, maxY);

            transform.localEulerAngles = new Vector3(-m_rotationY, rotationX, 0);
        }

        private void OnDisable()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}


