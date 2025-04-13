using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public List<Transform> escapePoints = new List<Transform>();
    public GameObject player;
    public bool GoToBed1 = false;
    public bool GoToBed2 = false;
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

    public void setGoToBed1(bool bed1)
    {
        GoToBed1 = bed1;

    }
    public void setGoToBed2(bool bed2)
    {
        GoToBed2 = bed2;

    }
    public bool getGoToBed1()
    {
        return GoToBed1;
    }
    public bool getGoToBed2()
    {
        return GoToBed2;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
