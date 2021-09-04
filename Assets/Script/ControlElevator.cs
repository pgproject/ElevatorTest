using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlElevator : MonoBehaviour, IAction
{
    [SerializeField] private Elevator m_elevator;
    [SerializeField] private int m_id;


    public void Execute()
    {
        m_elevator.ExecuteCoroutine(m_id, transform.position.y);
    }
}
