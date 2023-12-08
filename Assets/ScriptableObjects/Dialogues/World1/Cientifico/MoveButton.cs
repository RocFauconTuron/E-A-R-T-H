using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    [SerializeField] Transform parentPos;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().enabled = true;
        GetComponent<Image>().enabled = true;
        transform.parent = parentPos;
        transform.localPosition = Vector3.zero;
    }

}
