using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "new TriggerNode", menuName = "Dialogue/Triggers/ChangeScene", order = 0)]
public class ChangeSceneAfterDialogue : TriggerNode, iHaveNextNode
{
    [SerializeField]
    private string sceneName;
    public bool hasToDestroy = false;

    public override void Trigger()
    {
        //SceneManager.LoadScene(sceneName);
        if (hasToDestroy)
        {
            Destroy(FindObjectOfType<GuardarDatosUI1>().gameObject);
        }
        else
        {
            FindObjectOfType<GuardarDatosUI1>().GetButtons();
        }
        FindObjectOfType<NextSceneButton>().ChangeLevel(sceneName);
    }   

    [SerializeField, Header("Next Node: (null) => EndNode")]
    private BaseNode nextDialogNode;
    public BaseNode nextNode { get => nextDialogNode; set { value = nextDialogNode; } }
}
