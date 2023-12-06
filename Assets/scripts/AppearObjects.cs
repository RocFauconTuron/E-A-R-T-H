using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearObjects : MonoBehaviour
{
    public List<Transform> objectsToShow;
    private List<Vector3> objScale = new List<Vector3>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            StartCoroutine(ShowObj());
        }
    }
    IEnumerator ShowObj()
    {
        objScale = new List<Vector3>();
        for (int i = 0; i < objectsToShow.Count; i++)
        {
            objScale.Add(objectsToShow[i].localScale);
            objectsToShow[i].localScale = Vector3.zero;
            objectsToShow[i].gameObject.SetActive(true);
        }
        float time = 0;
        while (time < 3)
        {
            time += Time.deltaTime;
            float percentageDuration = time / 3;
            for (int i = 0; i < objectsToShow.Count; i++)
            {
                objectsToShow[i].localScale = Vector3.Lerp(Vector3.zero, objScale[i], percentageDuration);
            }
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}

