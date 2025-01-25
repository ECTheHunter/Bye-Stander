using UnityEngine;

public class EscapePoints : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.gameManager.escapePoints.Add(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
