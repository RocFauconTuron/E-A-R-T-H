using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarDatosUI1 : MonoBehaviour
{
    [SerializeField] List<string> buttonNames;
    FindObj findObj;
    List<bool> activeList = new List<bool>();
    List<BaseNode> buttonNode = new List<BaseNode>();

    private static GuardarDatosUI1 guardarDatos;
    private void Awake()
    {
        if(guardarDatos != null)
        {
            Destroy(gameObject);
        }
        else
        {
            guardarDatos = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void GetButtons()
    {
        findObj = FindObjectOfType<FindObj>();
        activeList.Clear();
        buttonNode.Clear();
        foreach (var name in buttonNames)
        {
            activeList.Add(findObj.GetButton(name).activeSelf);
            buttonNode.Add(findObj.GetButton(name).GetComponent<PressButonForDialogue>()._node);
        }

    }
    public void SetButtons()
    {
        findObj = FindObjectOfType<FindObj>();
        for (int i = 0; i < buttonNames.Count; i++)
        {
            findObj.GetButton(buttonNames[i]).SetActive(activeList[i]);
            if (activeList[i])
            {
                findObj.GetButton(buttonNames[i]).GetComponent<PressButonForDialogue>()._node = buttonNode[i];
            }
        }
    }
}
