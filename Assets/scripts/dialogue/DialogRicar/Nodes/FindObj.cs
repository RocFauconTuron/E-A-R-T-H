using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObj : MonoBehaviour
{
    [SerializeField] GameObject buttonBeatriceObj;
    [SerializeField] GameObject buttonJohanObj;
    [SerializeField] GameObject buttonDanteObj;
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
            case "ButtonDante":
                buttonDanteObj.GetComponent<PressButonForDialogue>()._node = node;
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
            case "ButtonDante":
                buttonDanteObj.SetActive(true);
                break;
        }
    }
    public void desactivateButon(string buttonName)
    {
        switch (buttonName)
        {
            case "ButtonBeatrice":
                buttonBeatriceObj.SetActive(false);
                break;
            case "ButtonJohan":
                buttonBeatriceObj.SetActive(false);
                break;
            case "ButtonDante":
                buttonDanteObj.SetActive(false);
                break;
        }
    }
    public GameObject GetButton(string buttonName)
    {
        switch (buttonName)
        {
            case "ButtonBeatrice":
                return buttonBeatriceObj;
                break;
            case "ButtonJohan":
                return buttonJohanObj;
                break;
            case "ButtonDante":
                return buttonDanteObj;
                break;
        }
        return null;
    }
}
