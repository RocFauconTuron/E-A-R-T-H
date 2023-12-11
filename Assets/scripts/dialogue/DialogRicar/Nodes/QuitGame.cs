using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "new TriggerNode", menuName = "Dialogue/Triggers/QuitGame", order = 0)]
public class QuitGame : TriggerNode, iHaveNextNode
{
    public override void Trigger()
    {
        Application.Quit();
    }      

    [SerializeField, Header("Next Node: (null) => EndNode")]
    private BaseNode nextDialogNode;
    public BaseNode nextNode { get => nextDialogNode; set { value = nextDialogNode; } }
}
