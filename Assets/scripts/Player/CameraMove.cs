using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] float sens;
    [SerializeField] Transform orientation;
    [SerializeField] float smoothTime;

    float xRot;
    float yRot;
    float xSpeed, yspeed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens;

        yRot = transform.localEulerAngles.y + mouseX;
        xRot = transform.localEulerAngles.x - mouseY;

        if (xRot < 275 && xRot > 200)
        {
            xRot = 275;
        }
        else if (xRot < 100 && xRot > 85)
        {
            xRot = 85;
        }


        //transform.localRotation = Quaternion.Euler(Mathf.SmoothDampAngle(transform.localRotation.x, xRot, ref xSpeed, smoothTime), Mathf.SmoothDampAngle(transform.localRotation.y, yRot, ref yspeed, smoothTime), 0);
        transform.localRotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.localRotation = Quaternion.Euler(0, yRot, 0);
    }
}
