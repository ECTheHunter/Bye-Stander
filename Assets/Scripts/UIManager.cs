using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text interactionPrompt;

    public void ShowPrompt(string message)
    {
        interactionPrompt.text = message;
        interactionPrompt.gameObject.SetActive(true);
    }

    public void HidePrompt()
    {
        interactionPrompt.gameObject.SetActive(false);
    }
}
