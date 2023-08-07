using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float rotateSpeed;
    public float horsePower;
    public GameObject centerOfMass;
    public float wheelSpeed;
    float vertical;
    float horizontal;


    Rigidbody tankRb;
    Roll_Wheels rollL, rollR;
    Scroll_Track trackL, trackR;

    void Start()
    {
        tankRb = GetComponent<Rigidbody>();
        tankRb.centerOfMass = centerOfMass.transform.position;
        rollL = GameObject.Find("Panzer_VI_E_Wheels_L").GetComponent<Roll_Wheels>();
        rollR = GameObject.Find("Panzer_VI_E_Wheels_R").GetComponent<Roll_Wheels>();
        trackL = GameObject.Find("Panzer_VI_E_Track_L").GetComponent<Scroll_Track>();
        trackR = GameObject.Find("Panzer_VI_E_Track_R").GetComponent<Scroll_Track>();
    }

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        tankRb.AddRelativeForce(Vector3.forward * vertical * horsePower);
        rollL.rotationSpeed = vertical * wheelSpeed;
        rollR.rotationSpeed = vertical * wheelSpeed;
        trackL.scrollSpeed = vertical * wheelSpeed;
        trackR.scrollSpeed = vertical * wheelSpeed;



        horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontal * Time.deltaTime * rotateSpeed);
    
        if (horizontal < 0)
        {
            rollR.rotationSpeed = horizontal * wheelSpeed;
            trackR.scrollSpeed = horizontal * wheelSpeed;
            rollL.rotationSpeed = -horizontal * wheelSpeed;
            trackL.scrollSpeed = -horizontal * wheelSpeed;

        }
        if (horizontal > 0)
        {
            rollL.rotationSpeed = horizontal * wheelSpeed;
            trackL.scrollSpeed = horizontal * wheelSpeed;
            rollR.rotationSpeed = -horizontal * wheelSpeed;
            trackR.scrollSpeed = -horizontal * wheelSpeed;
        }

        print(horizontal);
    }
}
