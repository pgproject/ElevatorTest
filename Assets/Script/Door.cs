using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    private static readonly int OPEN = Animator.StringToHash("Open");

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>() != null)
            m_animator.SetBool(OPEN, true);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<PlayerController>() != null)
            m_animator.SetBool(OPEN, false);
    }
}
