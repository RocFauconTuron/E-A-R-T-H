using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobinaController : MonoBehaviour
{
    public BaseNode nodeBobina;
    public BaseNode nodeNoBobina;
    public PressButonForDialogue button;
    private void Start()
    {
        if (FindObjectOfType<HasObjectToEnd>().bobina)
        {
            button._node = nodeBobina;
        }
        else
        {
            button._node = nodeNoBobina;
        }
    }
}
