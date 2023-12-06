using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Cube"))
        {
            other.GetComponent<PlayerDie>().Die();
        }
    }
}
