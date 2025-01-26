using UnityEngine;
using DialogueEditor;
using UnityEngine.SceneManagement;
using TMPro;

public class Interactor : MonoBehaviour
{
    private InteractObject _currentInteractableObject;
    [SerializeField] private GameObject _interactionPrompt;
    [SerializeField] private NPCConversation FirstNPCconversation;
    [SerializeField] private NPCConversation FirstNPCconversation1;
    [SerializeField] private NPCConversation SecondNPCconversation;
    [SerializeField] private NPCConversation SecondNPCconversation1;
    private bool isMadeBeforeForFirst = false;
    private bool isMadeBeforeForSecond = false;
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionMaxDistance = 10f;
    [SerializeField] private LayerMask _interactionLayer;

    private readonly Collider[] _colliders = new Collider[4];
    [SerializeField] private int _numFound;
    [SerializeField] private bool showRay = true;

    void Start()
    {
        SoundManager.PlayMachineSound();
        SoundManager.PlayAlarmSound();
        SoundManager.PlaySpeakingSound();
    }
    private void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _interactionMaxDistance, _interactionLayer))
        {
            if(hit.collider.CompareTag("NPC1")|| hit.collider.CompareTag("NPC2")|| hit.collider.CompareTag("Bed")){
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

                if(Input.GetKeyDown(KeyCode.E) && !ConversationManager.Instance.IsConversationActive && (hit.collider.CompareTag("NPC1")|| hit.collider.CompareTag("NPC2")))
                {
                    if(hit.collider.CompareTag("NPC1")){
                        GameManager.gameManager.setGoToBed1(true);
                    }
                    if(hit.collider.CompareTag("NPC2")){
                        GameManager.gameManager.setGoToBed2(true);
                    }
                    if(!isMadeBeforeForFirst && hit.collider.CompareTag("NPC1")){
                        Debug.Log("First NPC conversation started");
                        ConversationManager.Instance.StartConversation(FirstNPCconversation);
                        isMadeBeforeForFirst = true;
                    }else if(!isMadeBeforeForSecond && hit.collider.CompareTag("NPC2")){
                        Debug.Log("Second NPC conversation started");
                    ConversationManager.Instance.StartConversation(SecondNPCconversation);
                    isMadeBeforeForSecond = true;
                    }else if(isMadeBeforeForFirst && hit.collider.CompareTag("NPC1")){
                        Debug.Log("First NPC second conversation started");
                        ConversationManager.Instance.StartConversation(FirstNPCconversation1);
                    } else if(isMadeBeforeForSecond && hit.collider.CompareTag("NPC2")){
                        Debug.Log("Second NPC second conversation started");
                        ConversationManager.Instance.StartConversation(SecondNPCconversation1);
                    }
                    
                    InteractableObject.Interact();
                }

                if(hit.collider.CompareTag("Bed")){
                    if(GameManager.gameManager.getGoToBed1() && GameManager.gameManager.getGoToBed2() && Input.GetKeyDown(KeyCode.E)){
                        SceneManager.LoadScene("Dream");
                    } else if (!GameManager.gameManager.getGoToBed1() || !GameManager.gameManager.getGoToBed2()){
                        TextMeshProUGUI text = _interactionPrompt.GetComponentInChildren<TextMeshProUGUI>();
                        text.text = "You need to talk to both NPCs first";
                    }
                    
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
    
