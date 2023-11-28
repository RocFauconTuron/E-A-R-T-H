using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    [SerializeField] float jumpforce;
    [SerializeField] Transform endPoint;
    [SerializeField] Transform highPoint;
    Vector3 startPoint;
    [SerializeField] float times;
    [SerializeField] GravityObjectController goc;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            StartCoroutine(startMoveObj(other.transform));
        }
        else if (other.CompareTag("Player"))
        {
            StartCoroutine(startMovePlayer(other.transform));
        }
    }
    IEnumerator startMoveObj(Transform obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        startPoint = obj.position;
        goc.canChangeGravity = true;
        for (int i = 0; i < times; i++)
        {
            obj.position = evaluate(i / times);
            yield return new WaitForEndOfFrame();
            if (goc.hasChangedGravity)
            {
                Debug.Log("asdasdsa");
                obj.GetComponent<Rigidbody>().isKinematic = false;
                StopAllCoroutines();
            }
        }
        obj.GetComponent<Rigidbody>().isKinematic = false;
    }
    IEnumerator startMovePlayer(Transform obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        startPoint = obj.position;
        GravityController gc = obj.GetComponent<GravityController>();
        for (int i = 0; i < times; i++)
        {
            obj.position = evaluate(i / times);
            yield return new WaitForEndOfFrame();
            if (gc.hasChangedGravity)
            {
                obj.GetComponent<Rigidbody>().isKinematic = false;
                StopAllCoroutines();
            }
        }
        obj.GetComponent<Rigidbody>().isKinematic = false;
    }
    public Vector3 evaluate(float t)
    {
        Vector3 ab = Vector3.Lerp(startPoint, highPoint.position, t);
        Vector3 bc = Vector3.Lerp(highPoint.position, endPoint.position, t);
        return Vector3.Lerp(ab, bc, t);
    }
    private void OnDrawGizmos()
    {
        for (int i = 0; i < 20; i++)
        {
            Gizmos.DrawWireSphere(evaluate(i / 20), 1f);
        }
    }
}
