using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class SoundManager : MonoBehaviour
{
    public enum SoundType{
        WALK,
        JUMP,
        LAND,
        RUN,
        SPEAKING,
        ALARM,
        MACHINES
    }

    [SerializeField] private SoundList[] soundLists;
    [SerializeField] private AudioSource SpeakingSound;
    [SerializeField] private AudioSource AlarmSound;
    [SerializeField] private AudioSource MachineSound;
  
    private static SoundManager instance;
    private AudioSource audioSource;
    private static float volume = 1f;
    void Awake(){
        instance = this;
    }
    public void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType soundType){
        
        AudioClip[] clips = instance.soundLists[(int)soundType].Sounds;
        AudioClip clipToPlay = clips[UnityEngine.Random.Range(0, clips.Length)];
        instance.audioSource.PlayOneShot(clipToPlay, volume);
        //instance.audioSource.PlayOneShot(instance.soundLists[(int)soundType], volume);
    }
    public static void PlaySpeakingSound(){
        instance.SpeakingSound.Play();
    }
     public static void PlayAlarmSound(){
        instance.AlarmSound.Play();
    }
    public static void PlayMachineSound(){
        instance.MachineSound.Play();
    }
    public static bool IsPlaying(){
        return instance.audioSource.isPlaying;
    }
    public static void StopSound(){
        instance.audioSource.Stop();
    }

    
    

    

#if UNITY_EDITOR
    private void OnEnable(){
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundLists, names.Length);
        for (int i = 0; i < soundLists.Length; i++)
        {
            soundLists[i].name = names[i];
        }
    }
#endif
}

[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds{get=>sounds;}
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] sounds;
}
