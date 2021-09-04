using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text m_elevatorIsMoving;
    [SerializeField] private float m_timeToSwitchOffInfo;
    
    private WaitForSeconds m_waitForSeconds;
    [SerializeField] private PlayerController m_playerController; 
    [SerializeField] private GameObject m_buttonHolder;
    private void Awake()
    {
        m_waitForSeconds = new WaitForSeconds(m_timeToSwitchOffInfo);
        
    }

    public void OpenUi(bool isMoving)
    {
        m_buttonHolder.SetActive(!isMoving);
        m_elevatorIsMoving.enabled = isMoving;
        if (isMoving)
        {
            StartCoroutine(SwitchOffInfoString());
        }
        else
        {
            
            m_playerController.m_input.currentActionMap = m_playerController.m_input.actions.actionMaps[1];
        }
    }

    private IEnumerator SwitchOffInfoString()
    {
        yield return m_waitForSeconds;

        m_elevatorIsMoving.enabled = false;
        m_playerController.m_input.currentActionMap = m_playerController.m_input.actions.actionMaps[0];
    }

    private void Update()
    {
        if (m_playerController.m_input.currentActionMap == m_playerController.m_input.actions.actionMaps[1] && m_playerController.m_input.currentActionMap["Cancel"].ReadValue<float>() > 0)
        {
            m_buttonHolder.SetActive(false);
            m_playerController.m_input.currentActionMap = m_playerController.m_input.actions.actionMaps[0];
        }
    }
}
