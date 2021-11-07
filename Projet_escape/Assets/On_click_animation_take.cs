using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_click_animation_take : MonoBehaviour
{
    Animator anim;
    public GameObject player;

    // Update is called once per frame
    public void On_click_button_animatio_take()
    {
        
        anim = GetComponent<Animator>();
        anim.SetBool("isTaking", true);
        Debug.Log("okokokokko");
    }
}
