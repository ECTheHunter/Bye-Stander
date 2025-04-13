using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitTrigger : MonoBehaviour
{

    [SerializeField] private GameObject _exitPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("RealLifeEnd");
        
            Debug.Log("Player has entered the exit trigger" + other.gameObject.name);
        
    }
    // Update is called once per frame
    
}
