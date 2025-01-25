using UnityEngine;
using DialogueEditor;

public class Interactor : MonoBehaviour
{
    
    [SerializeField] private NPCConversation conversation;
    [SerializeField] private NPCConversation conversation1;
    private bool isMadeBefore = false;
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionMaxDistance = 10f;
    [SerializeField] private LayerMask _interactionLayer;

    private readonly Collider[] _colliders = new Collider[4];
    [SerializeField] private int _numFound;
    [SerializeField] private bool showRay = true;

    private void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _interactionMaxDistance, _interactionLayer))
        {
            if(hit.collider.CompareTag("Touchable")){
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Hit " + hit.collider.name);
                    ConversationManager.Instance.StartConversation(conversation);
                    
                }
            }
            
            
        }
        

        if (showRay)
        {
            Debug.DrawRay(transform.position, transform.forward * _interactionMaxDistance, Color.yellow);
        }
    }

    }
    
