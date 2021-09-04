using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Elevator : MovmentObject
{

    private float m_startPosition;
    private float m_endPosition;

    private int m_currentFloorId = 3;
    private float m_length;

    private Vector2 m_startPoint => new Vector2(transform.position.x, m_startPosition);

    private Vector2 m_endPoint => new Vector2(transform.position.x, m_endPosition);
   
    

    public void ExecuteCoroutine(int floorId, float endPosition)
    {
        Debug .Log(m_isMove);
        if (m_isMove) return;
        Debug.Log(floorId + " " + m_currentFloorId);

        if(floorId == m_currentFloorId) return; 
        
        m_currentFloorId = floorId;

        if (floorId > m_currentFloorId)
        {
            m_moveDirection = true;

        }
        else
        {
            m_moveDirection = false;
        }
        m_normalize = 0;


        m_endPosition = endPosition;
        
        StartCoroutine(Move());
    }


    protected override IEnumerator Move()
    {
        m_isMove = true;
        m_startPosition = transform.position.y;
        m_length =  Mathf.Abs(m_startPosition) + Mathf.Abs(m_endPosition);
        while (true)
        {
            m_normalize += Time.fixedDeltaTime  / m_length * m_speed * (m_moveDirection ? -1 : 1);
            m_normalize = Mathf.Clamp01(m_normalize);
            
            m_rigidbody.MovePosition(Vector2.Lerp(m_startPoint, m_endPoint, Mathf.SmoothStep(0, 1, m_normalize)));
            if (m_normalize == 0 || m_normalize == 1 /*|| m_normalize == 0.5*/)
            {
                m_isMove = false;
                yield break;
            }
            
            yield return new WaitForFixedUpdate();

        }
    }

    private void OnValidate()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
}
