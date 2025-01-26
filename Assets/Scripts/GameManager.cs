using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public List<Transform> escapePoints = new List<Transform>();
    public GameObject player;
    private bool GoToWork{get; set;}
    private bool GoHome {get; set;}
    private bool GoToBed {get; set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
