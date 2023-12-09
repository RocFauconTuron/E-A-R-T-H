using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObj : MonoBehaviour
{
    [SerializeField] GameObject buttonBeatriceObj;
    [SerializeField] GameObject buttonJohanObj;
    public void DoAction (BaseNode node, string buttonName)
    {
        switch (buttonName)
        {
            case "ButtonBeatrice":
                buttonBeatriceObj.GetComponent<PressButonForDialogue>()._node = node;
                break;
            case "ButtonJohan":
                buttonJohanObj.GetComponent<PressButonForDialogue>()._node = node;
                break;
        }
    }
    public void activateButon (string buttonName)
    {
        switch (buttonName)
        {
            case "ButtonBeatrice":
                buttonBeatriceObj.SetActive(true);
                break;
            case "ButtonJohan":
                buttonBeatriceObj.SetActive(true);
                break;
        }
    }

}
