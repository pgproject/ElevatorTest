using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovmentObject : MonoBehaviour
{
    [SerializeField] protected float m_speed;
    [SerializeField] protected Rigidbody m_rigidbody;
    
    protected float m_normalize;
    public bool m_isMove;
    protected bool m_moveDirection;
    protected abstract IEnumerator Move();
}
