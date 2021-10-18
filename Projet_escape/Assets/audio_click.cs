using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_click : MonoBehaviour
{
    [SerializeField] AudioSource audioClick;
    
    // Start is called before the first frame update
    void Start()
    {
        audioClick.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
