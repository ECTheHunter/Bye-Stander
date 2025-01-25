using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueEditor
{
    public class InputManager : MonoBehaviour
    {
        public KeyCode m_UpKey;
        public KeyCode m_UpKey2;
        public KeyCode m_DownKey;
        public KeyCode m_DownKey2;
        public KeyCode m_SelectKey;

        private void Update()
        {
            if (ConversationManager.Instance != null)
            {
                UpdateConversationInput();
            }
        }

        private void UpdateConversationInput()
        {
            if (ConversationManager.Instance.IsConversationActive)
            {
                if (Input.GetKeyDown(m_UpKey) || Input.GetKeyDown(m_UpKey2))
                    ConversationManager.Instance.SelectPreviousOption();
                else if (Input.GetKeyDown(m_DownKey) || Input.GetKeyDown(m_DownKey2))
                    ConversationManager.Instance.SelectNextOption();
                else if (Input.GetKeyDown(m_SelectKey))
                    ConversationManager.Instance.PressSelectedOption();
            }
        }
    }
}
