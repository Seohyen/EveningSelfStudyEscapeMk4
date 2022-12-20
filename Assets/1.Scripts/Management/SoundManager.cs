using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region
    public static SoundManager instance = null;

    public static SoundManager GetInstace()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }
    #endregion
    [SerializeField]
    private AudioSource audioBGMSource;
    [SerializeField]
    private AudioSource audioSFXSource;
    [SerializeField]
    private AudioSource audioClickSource;
    [SerializeField]
    private AudioSource audioWalkSource;
    [SerializeField]
    private AudioSource audioRunSource;
    [SerializeField]
    private AudioSource audioDoorSource; 
    private void Start()
    {
    }

    public void SFXPlay(AudioSource source)
    {
        audioSFXSource.Play();
    }
    public void SFXStop()
    {
        audioSFXSource.Stop();
    }

    // BGM
    public void BGMStop()
    {
        audioBGMSource.Stop();
    }
    public void BGMStart()
    {
        audioBGMSource.Play();
    }

    // 터치 시 사운드
    public void ClickSound()
    {
        audioClickSource.Stop();
        audioClickSource.Play();
    }

    public void SoundEffect()
    {
        audioSFXSource.Stop();
        audioSFXSource.Play();
    }

    public void Update()
    {
    }

    public void DoorSoundPlay()
    {
        audioDoorSource.Play();
    }
    
    public void DoorSoundStop()
    {
        audioDoorSource.Stop();
    }

    public void RunSoundPlay()
    {

        audioRunSource.Play();
    }
    public void RunSoundStop()
    {
        audioRunSource.Stop();
    }
    public void WalkSoundPlay()
    {

        audioWalkSource.Play();
    }
    public void WalkSoundStop()
    {
        audioWalkSource.Stop();
    }
}
