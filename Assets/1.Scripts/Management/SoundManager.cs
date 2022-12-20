using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region
    public static SoundManager _Instance = null;

    public static SoundManager GetInstace()
    {
        return _Instance;
    }

    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
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

    private void Start()
    {
        audioWalkSource = gameObject.AddComponent<AudioSource>();
    }

    public void SFXPlay(AudioClip clip)
    {
        audioSFXSource.Stop();
        audioSFXSource.PlayOneShot(clip);
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
        WalkSoundPlay();
    }

    public void WalkSoundPlay()
    {
        Debug.Log("WalkSoundPlay!");
        audioWalkSource.Play();
    }
    public void WalkSoundStop()
    {
        audioWalkSource.Stop();
    }
}
