using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class SoundManager : MonoBehaviour
{
    public enum SoundType{
        WALK,
        JUMP,
        LAND,
        RUN
    }

    [SerializeField] private SoundList[] soundLists;
    private static SoundManager instance;
    private AudioSource audioSource;
    void Awake(){
        instance = this;
    }
    public void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType soundType, float volume = 1){
        
        AudioClip[] clips = instance.soundLists[(int)soundType].Sounds;
        AudioClip clipToPlay = clips[UnityEngine.Random.Range(0, clips.Length)];
        instance.audioSource.PlayOneShot(clipToPlay, volume);
        //instance.audioSource.PlayOneShot(instance.soundLists[(int)soundType], volume);
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
