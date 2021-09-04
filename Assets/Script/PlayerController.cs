using System;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Script
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody m_rigidbody;
        [SerializeField] private float m_speedMoving;
        [SerializeField] public PlayerInput m_input;
        private IAction m_iAction;

        [SerializeField] private Camera m_camera;
        [SerializeField] private InputActionProperty m_mouse;
        public Cursor Cursor;
        private void Start()
        {
        }

        private Vector2 m_mousePos;
        private void Update()
        {
            /*if(!m_input.actions.actionMaps[0]".enabled) return;*/
            Debug.Log(m_input.currentActionMap["MousePosition"].ReadValue<Vector2>());

            if(m_input.currentActionMap["MoveForward"].ReadValue<float>() > 0)
                m_rigidbody.MovePosition(transform.position + Vector3.forward * m_speedMoving);
            
            if(m_input.currentActionMap["MoveBack"].ReadValue<float>() > 0)
                m_rigidbody.MovePosition(transform.position + Vector3.back * m_speedMoving);
            
            if(m_input.currentActionMap["MoveLeft"].ReadValue<float>() > 0)
                m_rigidbody.MovePosition(transform.position + Vector3.left * m_speedMoving);
            
            if(m_input.currentActionMap["MoveRight"].ReadValue<float>() > 0)
                m_rigidbody.MovePosition(transform.position + Vector3.right * m_speedMoving);

           
            if(m_input.currentActionMap["Action"].ReadValue<float>() > 0)
            {
                m_iAction?.Execute();
            }
            transform.Rotate(new Vector3(0, m_mouse.reference.action.ReadValue<Vector2>().x, 0));
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
