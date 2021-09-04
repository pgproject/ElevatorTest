using UnityEngine;

namespace Script
{
    public class ControllElevatorInsiade : MonoBehaviour, IAction
    {
        [SerializeField] private UIController m_uiController;
        public void Execute()
        {
            m_uiController.OpenUi(false);
        }
    }
}
