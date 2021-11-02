using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torchcontrol : MonoBehaviour
{
    bool toggled = false;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.gameObject.SetActive(toggled);
    }

    public void ToggleLamp()
    {
        toggled = !toggled;
        this.transform.gameObject.SetActive(toggled);
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
}
