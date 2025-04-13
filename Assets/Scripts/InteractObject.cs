using UnityEngine;
using UnityEngine.Events;

public class InteractObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public string InteractionText = "Press E to interact";
   public UnityEvent OnInteract;

   public string GetInteractionText(){
         return InteractionText;
   }
   public void Interact(){
       OnInteract.Invoke();
   }
}
