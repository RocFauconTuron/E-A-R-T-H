using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpObj : MonoBehaviour
{
    [SerializeField] Transform otherTp;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Cube"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            //other.transform.position = new Vector3(otherTp.localPosition.x +, otherTp.localPosition.y, otherTp.localPosition.z);
            //other.transform.position = otherTp.position;
            var relPoint = transform.InverseTransformPoint(other.transform.position);
            var relVelocity = -transform.InverseTransformDirection(rb.velocity);
            rb.velocity = otherTp.TransformDirection(relVelocity);
            other.transform.position = otherTp.TransformPoint(relPoint) + (rb.velocity.normalized * 1);
            if (other.CompareTag("Player"))
            {
                Transform cam = other.transform.GetChild(1).GetChild(0);
                Transform orientation = other.transform.GetChild(0);
                cam.eulerAngles = new Vector3(cam.localEulerAngles.x, otherTp.eulerAngles.y, cam.localEulerAngles.z);
                orientation.eulerAngles = new Vector3(orientation.localEulerAngles.x, otherTp.eulerAngles.y, orientation.localEulerAngles.z);
                other.GetComponent<PlayerMovementTutorial>().canControlSpeed = false;
                other.GetComponent<GravityController>().canChangeGravity = true;
            }
            else
            {

            }

        }
    }
}
