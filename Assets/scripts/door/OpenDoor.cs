using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] int keysToOpenDoor;
    int keys;
    GameObject door1;
    GameObject door2;
    private void Awake()
    {
        door1 = transform.GetChild(0).gameObject;
        door2 = transform.GetChild(1).gameObject;
    }

    public void GetKeyToOpen()
    {
        keys++;
        if(keys >= keysToOpenDoor)
        {
            door1.GetComponent<Animator>().SetBool("abrir", true);
            door2.GetComponent<Animator>().SetBool("abrir", true);
        }
    }
    public void OpenDoorFunction()
    {
        door1.GetComponent<Animator>().SetBool("abrir", true);
        door2.GetComponent<Animator>().SetBool("abrir", true);
    }
}
