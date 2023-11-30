using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlayerDetecto : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] Transform camPos;
    bool canCheck = false;
    ChangeGravityDynamic changeGravity;
    [SerializeField] List<CubeGravityGround> gravityCubesList;
    [SerializeField] List<GameObject> walls;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(true);
            canCheck = true;
            changeGravity = other.GetComponent<ChangeGravityDynamic>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(false);
            canCheck = false;
        }
    }
   
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && canCheck)
        {
            changeGravity.ChangeDynamic(camPos,gravityCubesList, walls);
        }
    }
}
