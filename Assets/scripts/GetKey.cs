using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    [SerializeField] OpenDoor openDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Cube"))
        {
            openDoor.GetKeyToOpen();
            Destroy(gameObject);
        }
    }
}
