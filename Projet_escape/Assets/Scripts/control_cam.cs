using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_cam : MonoBehaviour
{
    public float movForce = 50;
    public Transform targetTransform;
    public float offsetx = 10;
    public float offsety = 10;
    private Rigidbody mrigid;
    Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        mrigid = GetComponent<Rigidbody>();
        PlayerPrefs.SetFloat("offsettx", offsetx);
        PlayerPrefs.SetFloat("offsetty", offsety);
        PlayerPrefs.SetFloat("force_cam", movForce);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetTransform.position);
        //destination = targetTransform.position - (targetTransform.forward * offsetx - targetTransform.up * offsety);
        destination = targetTransform.position - (targetTransform.forward*PlayerPrefs.GetFloat("offsettx") - targetTransform.up* PlayerPrefs.GetFloat("offsetty")) ;
        //Debug.Log(destination);
        //mrigid.AddForce((-transform.position + destination) * movForce);
        mrigid.AddForce((-transform.position + destination) * PlayerPrefs.GetFloat("force_cam"));
    }



}
