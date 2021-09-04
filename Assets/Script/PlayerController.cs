using System;
using UnityEngine;

namespace Script
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody m_rigidbody;
        [SerializeField] private float m_speedMoving;

        private IAction m_iAction;
        private void Update()
        {
            if(Input.GetKey(KeyCode.W))
                m_rigidbody.MovePosition(transform.position + Vector3.forward * m_speedMoving);
            
            if(Input.GetKey(KeyCode.S))
                m_rigidbody.MovePosition(transform.position + Vector3.back * m_speedMoving);
            
            if(Input.GetKey(KeyCode.A))
                m_rigidbody.MovePosition(transform.position + Vector3.left * m_speedMoving);
            
            if(Input.GetKey(KeyCode.D))
                m_rigidbody.MovePosition(transform.position + Vector3.right * m_speedMoving);

            if (Input.GetKeyDown(KeyCode.E) && m_iAction != null)
            {
                m_iAction.Execute();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<IAction>() != null)
                m_iAction = other.GetComponent<IAction>();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<IAction>() != null)
                m_iAction = null;
        }
    }
    
}
