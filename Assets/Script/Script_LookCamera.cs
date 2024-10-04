using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_LookCamera : MonoBehaviour
{
        public Transform m_Camera;

        void Start()
        {
            m_Camera = Camera.main.transform; // ���� ī�޶� ã��
        }

        void Update()
        {
            Vector3 targetPos = new Vector3(m_Camera.position.x, transform.position.y, m_Camera.position.z);
            transform.LookAt(targetPos); // ī�޶� �ٶ󺸰� ����
            transform.Rotate(0, 180, 0);
        }
   }

