using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "new TriggerNode", menuName = "Dialogue/Triggers/ActivateGameObject", order = 0)]
public class ActivateGameObjedcts : TriggerNode, iHaveNextNode
{
    public List<string> objectNames;
    public override void Trigger()
    {
        for (int i = 0; i < objectNames.Count; i++)
        {
            GameObject.Find("FindObjController").GetComponent<FindObj>().activateButon(objectNames[i]);
        }
    }   

    [SerializeField, Header("Next Node: (null) => EndNode")]
    private BaseNode nextDialogNode;
    public BaseNode nextNode { get => nextDialogNode; set { value = nextDialogNode; } }
}
