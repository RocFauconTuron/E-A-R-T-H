using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovementTutorial>().enabled = false;
            other.GetComponent<GravityController>().enabled = false;
            other.transform.GetChild(1).GetChild(0).GetComponent<CameraMove>().enabled = false;
        }
    }
}
