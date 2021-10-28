using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFurniture : MonoBehaviour
{
    private GameObject player;
    private const string animBoolName = "isOpen_Obj_";
    Animator anim;
    public float reachRange = 1.8f;
    MoveableObject moveableObject;
    bool playerEnter = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)     //player has collided with trigger
        {
            playerEnter = true;
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)     //player has exited trigger
        {
            playerEnter = false;
        }
    }

            // Update is called once per frame
            void Update()
    {
        if (playerEnter)
        {
            anim.SetBool("isOpen_Obj_1", true);
        }
        else
        {
            anim.SetBool("isOpen_Obj_1", false);
        }
    }
}
