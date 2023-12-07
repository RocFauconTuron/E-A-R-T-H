using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaPresionCubo : MonoBehaviour
{
    [SerializeField] GameObject door;
    public bool anim;
    public bool canInteractWithPlayer = false;
    public bool canAppearObj = false;
    public GameObject objToAppear;
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
            if (canAppearObj)
            {
                objToAppear.SetActive(true);
            }
            
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
        else if(canInteractWithPlayer && other.CompareTag("Player"))
        {
            if (anim)
            {
                door.GetComponent<Animator>().SetTrigger("anim");
            }
            else
            {
                Destroy(door);
            }
            Destroy(gameObject);
        }
    }
}
