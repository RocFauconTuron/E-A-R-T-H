using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "new TriggerNode", menuName = "Dialogue/Triggers/ChangeDialogueForButton", order = 0)]
public class ChangeDialogueForButton : TriggerNode, iHaveNextNode
{
    public string buttonName;
    public BaseNode buttonNode;
    public override void Trigger()
    {
        GameObject.Find("FindObjController").GetComponent<FindObj>().DoAction(buttonNode, buttonName);
    }   

    [SerializeField, Header("Next Node: (null) => EndNode")]
    private BaseNode nextDialogNode;
    public BaseNode nextNode { get => nextDialogNode; set { value = nextDialogNode; } }
}
