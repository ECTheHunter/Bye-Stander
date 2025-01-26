using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    
    [SerializeField] private Slider _volumeSlider;
    private void Start()
    {
        SetVolume(1f);
    }


    public void SetVolume(float value){
        if(value <0){
            value = 1f;
        }

        RefreshSlider(value);
        SoundManager.SetVolume(value);
    }

    public void setFromSlider(){
        SetVolume(_volumeSlider.value);
    }
    // Update is called once per frame
    public void RefreshSlider(float value){
         _volumeSlider.value = value;
    }
}
