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
        if(TooClosePlayerDistance()){
            int randomnumber = Random.Range(0, GameManager.instance.escapePoints.Count-1);
            Debug.Log(randomnumber);
        }

    }
    public bool TooClosePlayerDistance()
    {
        Transform playerPosition = GameManager.instance.player.transform;
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
