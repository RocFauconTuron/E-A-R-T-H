using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveWhenFar : MonoBehaviour
{
    float horizontalInput;
    [SerializeField] float speed;
    public Transform limitZoneLeft;
    public Transform limitZoneRight;
    [SerializeField] float sens;
    float rotAngle;
    public Transform outsideCam;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        transform.localPosition += new Vector3(horizontalInput * Time.deltaTime * speed, 0, 0);

        if (transform.localPosition.x > limitZoneRight.localPosition.x)
        {
            transform.localPosition = new Vector3(limitZoneRight.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }
        else if (transform.localPosition.x < limitZoneLeft.localPosition.x)
        {
            transform.localPosition = new Vector3(limitZoneLeft.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }
    }
    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens;
            rotAngle -= mouseY;
            rotAngle = Mathf.Clamp(rotAngle, -35, 45f);

            //transform.localRotation = Quaternion.Euler(Mathf.SmoothDampAngle(transform.localRotation.x, xRot, ref xSpeed, smoothTime), Mathf.SmoothDampAngle(transform.localRotation.y, yRot, ref yspeed, smoothTime), 0);
            outsideCam.localRotation = Quaternion.Euler(0, 0, rotAngle);
        }
        
    }
}
