using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObj : MonoBehaviour
{
    [SerializeField] GameObject buttonBeatriceObj;
    public void DoAction (BaseNode node, string buttonName)
    {
        switch (buttonName)
        {
            case "ButtonBeatrice":
                buttonBeatriceObj.GetComponent<PressButonForDialogue>()._node = node;
                break;
        }
    }
}
