using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using DialogueEditor;
public class NPC : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();


    }

    // Update is called once per frame
    void Update()
    {

        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            navMeshAgent.ResetPath();
        }
        if (navMeshAgent.velocity.magnitude < 0.25f || ConversationManager.Instance.IsConversationActive)
        {
            animator.SetBool("walking", false);
        }
        else
        {
            animator.SetBool("walking", true);
        }
        if (ConversationManager.Instance.IsConversationActive)
        {
            navMeshAgent.speed = 0;
        }
        else
        {
            navMeshAgent.speed = 5;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {

            if (!navMeshAgent.hasPath)
            {
                int randomnumber = Random.Range(0, GameManager.gameManager.escapePoints.Count - 1);
                navMeshAgent.destination = GameManager.gameManager.escapePoints[randomnumber].position;
            }

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (!navMeshAgent.hasPath)
            {
                int randomnumber = Random.Range(0, GameManager.gameManager.escapePoints.Count - 1);
                navMeshAgent.destination = GameManager.gameManager.escapePoints[randomnumber].position;
            }

        }
    }
}
