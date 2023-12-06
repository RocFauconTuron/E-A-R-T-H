using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaPresionCubo : MonoBehaviour
{
    [SerializeField] GameObject door;
    public bool anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            if (anim)
            {

                door.GetComponent<Animator>().SetTrigger("anim");
            }
            else
            {
                Destroy(door);
            }
            
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
