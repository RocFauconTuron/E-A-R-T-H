using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorInPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")|| other.CompareTag("Cube"))
        {
            other.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Cube"))
        {
            other.transform.parent = null;
        }
    }
}
