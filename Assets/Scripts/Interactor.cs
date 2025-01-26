using UnityEngine;
using DialogueEditor;
using UnityEngine.SceneManagement;
using TMPro;

public class Interactor : MonoBehaviour
{
    private InteractObject _currentInteractableObject;
    [SerializeField] private GameObject _interactionPrompt;
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
            if(hit.collider.CompareTag("Touchable")|| hit.collider.CompareTag("Bed")){
                InteractObject InteractableObject = hit.collider.GetComponent<InteractObject>();

                if(InteractableObject != null && InteractableObject != _currentInteractableObject)
                {
                    _currentInteractableObject = InteractableObject;
                    _interactionPrompt.SetActive(true);
                    TextMeshProUGUI text = _interactionPrompt.GetComponentInChildren<TextMeshProUGUI>();
                    if(text != null){
                        text.text = _currentInteractableObject.GetInteractionText();
                    }
                }
                else if(InteractableObject == null)
                {
                    _currentInteractableObject = null;
                    _interactionPrompt.SetActive(false);
                }

                if(Input.GetKeyDown(KeyCode.E) && !ConversationManager.Instance.IsConversationActive && hit.collider.CompareTag("Touchable"))
                {
                    InteractableObject.Interact();
                    if(isMadeBefore){
                        ConversationManager.Instance.StartConversation(conversation1);
                    } else{
                        Debug.Log("Hit " + hit.collider.name);
                    ConversationManager.Instance.StartConversation(conversation);
                    isMadeBefore = true;
                    }
                    
                    
                }

                if(hit.collider.CompareTag("Bed")){
                    SceneManager.LoadScene("Dream");
                }
            } 
            
            
        } else {
            _currentInteractableObject = null;
            _interactionPrompt.SetActive(false);
        }
        if(ConversationManager.Instance.IsConversationActive){
            _currentInteractableObject = null;
            _interactionPrompt.SetActive(false);
        }
        

        if (showRay)
        {
            Debug.DrawRay(transform.position, transform.forward * _interactionMaxDistance, Color.yellow);
        }
    }

    }
    
