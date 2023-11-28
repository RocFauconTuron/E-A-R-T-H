using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaPresionCubo : MonoBehaviour
{
    [SerializeField] GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            Destroy(door);
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

}
