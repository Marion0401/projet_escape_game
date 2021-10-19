using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform Target;
    [SerializeField] public float CameraDist = 2f;
    private Vector3 Rotation;
    private Vector3 PositionCorr;
    [SerializeField] int heightOffset = 1;




    [Range(1, 10)] public int sensitivity = 5;

    void Start()
    {
        transform.position = Target.transform.position + CameraDist * (3) * (-1)*Target.forward;
        transform.LookAt(Target.transform.position + Vector3.up);
    }



    void Update()
    {

        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);

        //Rotation.z = 0;
        Rotation.x -= Input.GetAxis("Mouse Y") * sensitivity / 2 * Time.deltaTime;
        Rotation.y -= Input.GetAxis("Mouse X") * sensitivity / 2 * Time.deltaTime;

        PositionCorr = Target.position + heightOffset * Vector3.up + 
            (-(float)System.Math.Cos(Rotation.y) * Vector3.right
            + (Rotation.x) * Vector3.up
            - (float)System.Math.Sin(Rotation.y) * Vector3.forward).normalized * CameraDist;

        PositionCorr.y = Mathf.Clamp(PositionCorr.y, Target.position.y + heightOffset - 0.2f, Target.position.y + heightOffset + 10 * CameraDist / 10);

        if(System.Math.Sqrt(System.Math.Pow(PositionCorr.x - Target.position.x, 2)  + System.Math.Pow(PositionCorr.z - Target.position.z, 2)) < 2.5f)
        {
            PositionCorr.y = transform.position.y;
        }

        transform.position = PositionCorr;


        transform.LookAt(Target.transform.position + heightOffset * Vector3.up);


    }
}
