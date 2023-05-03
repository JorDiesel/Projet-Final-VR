using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void setMasterSound(float volume)
    {
        audioMixer.SetFloat("MasterVol", volume);
    }

    public void setEffetsSound(float volume)
    {
        audioMixer.SetFloat("EffetsVol", volume);
    }

    public void setAmbianceSound(float volume)
    {
        audioMixer.SetFloat("AmbianceVol", volume);
    }
}
