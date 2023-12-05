using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mymixer;

    [SerializeField] private Slider musicSlider;

    public void Setmusicvolume()
    {
        float volume = musicSlider.value;
        mymixer.SetFloat("music", Mathf.Log10(volume)*20);
    }
}
