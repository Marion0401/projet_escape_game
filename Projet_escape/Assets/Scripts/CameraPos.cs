using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] public float CameraDist = 2f;
    private Vector3 Rotation;
    [SerializeField] private float _tLerpSpeed = 0.5f;

    [Range(-45, -15)] public int minAngle = -30;
    [Range(30, 80)] public int maxAngle = 45;
    [Range(200, 2000)] public int sensitivity = 500;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Target.transform.position + CameraDist * Vector3.up + CameraDist * (2) * Vector3.back;
        transform.LookAt(Target.transform.position + Vector3.up);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target.transform.position + Vector3.up);
        Rotation.x -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        //camPosition = 2 * camera.CameraDist * Vector3.up + camera.CameraDist * 3 * Vector3.back;
        //camPosition.y += Input.GetAxis("Mouse Y") * Time.deltaTime*10;
        Rotation.x = Mathf.Clamp(Rotation.x, minAngle, maxAngle);
        //camPosition.y = Mathf.Clamp(camRotation.y, minAngle, maxAngle);

        transform.Rotate(Rotation + Vector3.up * sensitivity * Time.deltaTime * Input.GetAxis("Mouse X"));




        //transform.position = Target.transform.position + 4 * Vector3.up + 4 * Vector3.back;
        Vector3 destination = Target.position + (Vector3.up * CameraDist) + (Vector3.back * CameraDist * 2);
        transform.position = Vector3.Lerp(transform.position, destination, _tLerpSpeed);
    }
}
