using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{

    [SerializeField] private Transform Target;
    [Range(2, 8)] public float CameraDist = 2f;
    public bool Rotate = true;
    Vector3 _cameraOffset;
    Vector3 newPos;

    [Range(0, 10)] public float smoothMove = 2.0f;
    [Range(1, 10)] public int sensitivity = 2;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Target.transform.position + CameraDist * (-1) * Target.forward + CameraDist * Vector3.up;
        transform.LookAt(Target.transform.position + Vector3.up);
        _cameraOffset = transform.position - Target.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButton(1))
        {
            Rotate = true;
            _cameraOffset = transform.position - Target.position;
        }
        else
        {
            Rotate = true;
            newPos = Target.transform.position + CameraDist * (-1) * Target.forward + CameraDist * Vector3.up;

            transform.position = Vector3.Lerp(transform.position, newPos, smoothMove);
        }*/

        //Rotation verticale
        if (Rotate) 
        {
            Quaternion camTurnAngle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensitivity, Vector3.up);

            _cameraOffset = camTurnAngle * _cameraOffset;


            newPos = Target.position + 2 * Vector3.up + _cameraOffset;

            transform.position = Vector3.Slerp(transform.position, newPos, smoothMove);
        }

        //Rotation verticale
        if (Rotate)
        {

           
            Quaternion camTurnAngle =
             Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * sensitivity, transform.right);

            _cameraOffset = camTurnAngle * _cameraOffset;

            newPos = Target.position + 2 * Vector3.up + _cameraOffset;

            newPos.y = Mathf.Clamp(newPos.y, 0.2f, Target.position.y + 7f);

            transform.position = Vector3.Slerp(transform.position, newPos, smoothMove);

        }


        transform.LookAt(Target.position + 2 * Vector3.up);

    }
}
