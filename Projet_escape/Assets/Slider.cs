using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{

    [SerializeField] private Text chiffre_volume;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void VolumeSlider(float volume)
    {
        volume = volume * 10;
        chiffre_volume.text = volume.ToString("0.0");
    }
}
