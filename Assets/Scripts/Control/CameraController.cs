using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float sens;
    public GameObject cam360;
    public GameObject gun;
    public GameObject turret;

    float boundUpDown;
    float setCameraYpos;
    float setGunRotationX;
    public float cameraMaxYpos;
    public float cameraMinYpos;
    public float upperBound;
    public float lowerBound;
    public float gunMax;
    public float gunMin;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //360 Cam
        float mouseX = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        cam360.transform.Rotate(Vector3.up * mouseX); // sað-sol

        //Camera
        float mouseY = Input.GetAxis("Mouse Y") * sens / 2 * Time.deltaTime;
        boundUpDown -= mouseY; // Y deki açýlarýn toplamý boundUpDown da toplandý
        boundUpDown = Mathf.Clamp(boundUpDown, lowerBound, upperBound); // Y deki açý sýnýrlandýrýldý
        transform.localRotation = Quaternion.Euler(boundUpDown, 0, 0); // yukarý-aþaðý

        setCameraYpos -= mouseY / 4.5f;
        setCameraYpos = Mathf.Clamp(setCameraYpos, cameraMinYpos, cameraMaxYpos);
        transform.position = new Vector3(transform.position.x, setCameraYpos, transform.position.z);

        setGunRotationX -= mouseY / 2f;
        setGunRotationX = Mathf.Clamp(setGunRotationX, gunMin, gunMax);
        gun.transform.localRotation = Quaternion.Euler(setGunRotationX, 0, 0);


    }
}
