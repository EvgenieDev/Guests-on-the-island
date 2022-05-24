using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundLevel : MonoBehaviour
{
    public AudioMixer audioMixer; //Регулятор громкости
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Resources.volume);
        audioMixer.SetFloat("MasterVolume", Resources.volume); //Изменение уровня громкости
    }
}
