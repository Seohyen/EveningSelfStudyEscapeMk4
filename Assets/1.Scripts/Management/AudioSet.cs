using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioSet : MonoBehaviour
{
    public Slider BGMSlider;
    public Slider FXSlider;

    private float backVol = 1;
    private float vfxVol = 1;

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
        SetVolume();
    }
    private void SetVolume()
    {
        audioBGMSource.pitch = 1f;

        backVol = PlayerPrefs.GetFloat(ConstantManager.VOL_BACK, 1f);
        BGMSlider.value = backVol;

        vfxVol = PlayerPrefs.GetFloat(ConstantManager.VOL_VFX, 1f);
        FXSlider.value = vfxVol;
    }

    public void BGMSoundSlider()
    {
        audioBGMSource.volume = BGMSlider.value;
        backVol = BGMSlider.value;
        PlayerPrefs.SetFloat(ConstantManager.VOL_BACK, backVol);
    }
    public void FXSoundSlider()
    {
        audioSFXSource.volume = FXSlider.value;
        audioWalkSource.volume = FXSlider.value;
        audioRunSource.volume = FXSlider.value;
        audioDoorSource.volume = FXSlider.value;

        vfxVol = FXSlider.value;
        PlayerPrefs.SetFloat(ConstantManager.VOL_VFX, vfxVol);
    }
}
