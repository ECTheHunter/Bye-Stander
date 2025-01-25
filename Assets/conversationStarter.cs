using UnityEngine;
using DialogueEditor;
using System;
public class conversationStarter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private NPCConversation conversation;
    [SerializeField] private NPCConversation conversation1;
    private bool isMadeBefore = false;
    private int count = 0;

    private void OnTriggerStay(Collider other){

        if(other.CompareTag("Player")){

            if(Input.GetKeyDown(KeyCode.F)&& !ConversationManager.Instance.IsConversationActive)
            {
                if(isMadeBefore )
                {
                    
                    ConversationManager.Instance.StartConversation(conversation1);
                }
                else
                {
                    ConversationManager.Instance.StartConversation(conversation);
                    count++;
                    if(count == 2)
                    {
                        isMadeBefore = true;
                        
                    }
                }
                
            }
        }
    }
    
}
