using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_LookCamera : MonoBehaviour
{
        public Transform m_Camera;

        void Start()
        {
            m_Camera = Camera.main.transform; // 메인 카메라를 찾음
        }

        void Update()
        {
            Vector3 targetPos = new Vector3(m_Camera.position.x, transform.position.y, m_Camera.position.z);
            transform.LookAt(targetPos); // 카메라를 바라보게 설정
            transform.Rotate(0, 180, 0);
        }
   }

