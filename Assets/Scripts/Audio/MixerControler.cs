using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerControler : MonoBehaviour
{
    public AudioMixer mixer;
    [SerializeField] string musicParameter = "Music";
    [SerializeField] string efectsParameter = "Efects";
    public Slider musicSlider;
    public Slider efectsSlider;
    float tmp;

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(musicParameter);
        efectsSlider.value = PlayerPrefs.GetFloat(efectsParameter);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(musicParameter, musicSlider.value);
        PlayerPrefs.SetFloat(efectsParameter, efectsSlider.value);
    }
    public void SetLevelMusic(float sliderValue)
    {
        mixer.SetFloat(musicParameter, Mathf.Log10(sliderValue) * 20);
    }
    public void SetLevelEfects(float sliderValue)
    {
        mixer.SetFloat(efectsParameter, Mathf.Log10(sliderValue) * 20);
    }
    
}
