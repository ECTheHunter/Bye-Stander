using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    void Start()
    {
        SoundManager.PlayMachineSound();
        SoundManager.PlayAlarmSound();
        SoundManager.PlaySpeakingSound();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Play()
    {
        SceneManager.LoadScene("RealLife");
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}
