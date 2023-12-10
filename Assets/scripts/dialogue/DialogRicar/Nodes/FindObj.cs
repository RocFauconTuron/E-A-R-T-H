using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObj : MonoBehaviour
{
    [SerializeField] GameObject buttonBeatriceObj;
    [SerializeField] GameObject buttonJohanObj;
    [SerializeField] GameObject buttonDanteObj;
    [SerializeField] GameObject buttonAmeliaObj;
    [SerializeField] GameObject buttonOlafObj;
    [SerializeField] GameObject buttonLeorioObj;
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
            case "ButtonAmelia":
                buttonAmeliaObj.GetComponent<PressButonForDialogue>()._node = node;
                break;
            case "ButtonOlaf":
                buttonOlafObj.GetComponent<PressButonForDialogue>()._node = node;
                break;
            case "ButtonLeorio":
                buttonLeorioObj.GetComponent<PressButonForDialogue>()._node = node;
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
            case "ButtonAmelia":
                buttonAmeliaObj.SetActive(true);
                break;
            case "ButtonOlaf":
                buttonOlafObj.SetActive(true);
                break;
            case "ButtonLeorio":
                buttonLeorioObj.SetActive(true);
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
            case "ButtonAmelia":
                buttonAmeliaObj.SetActive(false);
                break;
            case "ButtonOlaf":
                buttonOlafObj.SetActive(false);
                break;
            case "ButtonLeorio":
                buttonLeorioObj.SetActive(false);
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
            case "ButtonAmelia":
                return buttonAmeliaObj;
                break;
            case "ButtonOlaf":
                return buttonOlafObj;
                break;
            case "ButtonLeorio":
                return buttonLeorioObj;
                break;
        }   
        return null;
    }
}
