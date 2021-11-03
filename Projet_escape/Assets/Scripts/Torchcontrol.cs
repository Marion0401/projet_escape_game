using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torchcontrol : MonoBehaviour
{
    bool toggled = false;
    [SerializeField] GameObject Lamp;
    // Start is called before the first frame update
    void Start()
    {
        Lamp.transform.gameObject.SetActive(toggled);

        this.GetComponent<Button>().onClick.AddListener(ToggleLamp);
    }

    
    public void ToggleLamp()
    {
        toggled = !toggled;
        Lamp.transform.gameObject.SetActive(toggled);
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
}
