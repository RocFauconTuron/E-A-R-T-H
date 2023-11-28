using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMechanicTimer : MonoBehaviour
{
    [SerializeField] float count;
    float timer;
    [SerializeField] string mechanic;
    [SerializeField] GravityController gravityController;
    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ActivateTimer());
        }
    }
    IEnumerator ActivateTimer()
    {
        timer += Time.deltaTime;
        while(timer < count)
        {
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("aaaaaaaaa");
        switch (mechanic)
        {
            case "gravity":
                gravityController.enabled = true;
                break;
        }
        Destroy(gameObject);
    }
}
