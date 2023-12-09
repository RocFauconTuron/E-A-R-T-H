using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "new TriggerNode", menuName = "Dialogue/Triggers/SetButtons", order = 0)]
public class SetButtons : TriggerNode, iHaveNextNode
{

    public override void Trigger()
    {
        FindObjectOfType<GuardarDatosUI1>().SetButtons();
    }   

    [SerializeField, Header("Next Node: (null) => EndNode")]
    private BaseNode nextDialogNode;
    public BaseNode nextNode { get => nextDialogNode; set { value = nextDialogNode; } }
}
