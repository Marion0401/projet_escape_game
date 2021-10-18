using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{

    public CharacterController characterController;
    public Transform Cam;
    public float speed;
    private Vector3 moveDirection;
    Vector3 CamRot;

    [Range(20, 1)]
    public int gravity = 10;
    [Range(200, 2000)]
    public int sensitivity = 500;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        /*if (Input.GetAxis("Mouse X") < 0)
        {
            //transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * 5 * mouseSensitivity, 0);
            print("left");
        }

        if (Input.GetAxis("Mouse X") > 0)
        {
            //transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * 5 * mouseSensitivity, 0);
            print("right");
        }*/


    }

    

    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        float upwardsMove = Input.GetAxis("Jump");
        
        if (characterController.isGrounded)
        {
            if (horizontalMove != 0 || verticalMove != 0 || upwardsMove != 0)
            {
                CamRot = transform.position + Cam.forward;
                CamRot.y = transform.position.y;
                transform.LookAt(CamRot);
            }


            moveDirection = new Vector3(horizontalMove, upwardsMove, verticalMove);
            moveDirection = transform.TransformDirection(moveDirection);
        }

        //CamRot.y = Cam.rotation.y;
        //transform.rotation = CamRot;
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * speed * Time.deltaTime);
    }
}
