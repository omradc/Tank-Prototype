using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    public Transform cam;
    [Range(0, 360)] public int t;

    void Update()
    {        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, cam.transform.rotation, t * Time.deltaTime);
    }
}
