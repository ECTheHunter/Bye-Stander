using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    public bool playerTooClose;
    public float triggerdistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TooClosePlayerDistance() && navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete){
            int randomnumber = Random.Range(0, GameManager.gameManager.escapePoints.Count);
            Debug.Log(randomnumber);
            navMeshAgent.destination = GameManager.gameManager.escapePoints[randomnumber].position;
        }
        Debug.Log(navMeshAgent.pathStatus);

    }
    public bool TooClosePlayerDistance()
    {
        Transform playerPosition = GameManager.gameManager.player.transform;
        float distance = Vector3.Distance(this.transform.position, playerPosition.position);
        if (distance < triggerdistance)
        {
            return true;
        }
        else
        {
            return false;
        }


    }
}
