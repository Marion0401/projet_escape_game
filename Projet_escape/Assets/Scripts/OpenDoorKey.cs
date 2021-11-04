using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class OpenDoorKey : MonoBehaviour
{
    private GameObject player;
    private const string animBoolName = "isOpen_Obj_";
    Animator anim;
    MoveableObject moveableObject;
    bool playerEnter = false;
    public Button buttonOpen;
    public PickUp key;
    private Inventory inventory;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = this.GetComponent<Animator>();
        inventory = player.GetComponent<Inventory>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)     //player has collided with trigger
        {
            buttonOpen.gameObject.SetActive(true);
            if (key.canEnter == true)
            {
                buttonOpen.onClick.AddListener(Open);
            }
            


        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)     //player has exited trigger
        {
            buttonOpen.gameObject.SetActive(false);

            playerEnter = false;
        }
    }

    void Open()
    {
        playerEnter = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerEnter)
        {
            anim.SetBool("isOpen_Obj_1", true);
            buttonOpen.gameObject.SetActive(false);
        }
        else
        {
            anim.SetBool("isOpen_Obj_1", false);
        }
    }
}
