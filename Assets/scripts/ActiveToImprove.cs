using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveToImprove : MonoBehaviour
{
    public List<GameObject> objectsToShow;
    public List<GameObject> objectsToHide;
    private List<Vector3> objScale = new List<Vector3>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < objectsToShow.Count; i++)
            {
                Debug.Log("se");
                objectsToShow[i].SetActive(true);
            }
            for (int i = 0; i < objectsToHide.Count; i++)
            {
                objectsToHide[i].SetActive(false);
            }
            Destroy(gameObject);
        }
    }
}
