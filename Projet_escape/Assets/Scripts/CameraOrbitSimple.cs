using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitSimple : MonoBehaviour
{
    [SerializeField] Transform InnerCube;
    public float CameraDist;
    Vector3 Rotation;
    Vector3 Position;

    [Range(1, 10)] public int sensitivity = 2;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = InnerCube.position - InnerCube.forward * CameraDist;
        Rotation = transform.rotation.eulerAngles;
        Position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(1))
        {
            Rotation.x -= Input.GetAxis("Mouse Y") * sensitivity;
            Rotation.y += Input.GetAxis("Mouse X") * sensitivity;

            Rotation.x = Mathf.Clamp(Rotation.x, -80f, 40f);
        }


        InnerCube.rotation = Quaternion.Euler(Rotation.x, Rotation.y, 0);
        
        
        

        Position = InnerCube.position + Vector3.up + InnerCube.forward * CameraDist;
        Position.y = Mathf.Clamp(Position.y, 0.2f, InnerCube.position.y + 10);


        transform.position = Position;
        transform.LookAt(InnerCube.position + Vector3.up);

    }
}