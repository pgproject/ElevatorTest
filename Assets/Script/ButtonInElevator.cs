using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonInElevator : MonoBehaviour
{
    [SerializeField] private Elevator m_elevator;
    [SerializeField] private List<Transform> m_dictionary = new List<Transform>();
    [SerializeField] private PlayerController m_playerController;
    [SerializeField] private EventSystem m_eventSystem;

    public void Click(int floor)
    {
        m_elevator.ExecuteCoroutine(floor, m_dictionary[floor - 1].position.y);
    }
    
    public void Close(GameObject goTOHide)
    {
        goTOHide.SetActive(false);
        m_playerController.m_input.currentActionMap = m_playerController.m_input.actions.actionMaps[0];
    }
    
    
}
