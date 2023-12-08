using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearPlatform : MonoBehaviour
{
    GravityController gc;
    GravityObjectController goc;
    [SerializeField] Material iceMat;
    [SerializeField] Material invisibleMat;
    BoxCollider boxCollider;
    MeshRenderer meshRenderer;
    [SerializeField] float timer;

    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GravityController>();
        goc = FindObjectOfType<GravityObjectController>();
        boxCollider = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gc.hasChangedGravity || goc.hasChangedGravity)
        {
            StopAllCoroutines();
            StartCoroutine(ChangeMat());
        }
    }
    IEnumerator ChangeMat()
    {
        boxCollider.enabled = true;
        meshRenderer.material = iceMat;
        yield return new WaitForSeconds(timer);
        boxCollider.enabled = false;
        meshRenderer.material = invisibleMat;
    }
}
