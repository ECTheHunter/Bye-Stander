using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    void Start()
    {
        SoundManager.PlaySound(SoundManager.SoundType.MACHINES);
        SoundManager.PlaySound(SoundManager.SoundType.ALARM);
        SoundManager.PlaySound(SoundManager.SoundType.SPEAKING);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Play()
    {
        SceneManager.LoadScene("RealLife");
    }

    // Update is called once per frame
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
