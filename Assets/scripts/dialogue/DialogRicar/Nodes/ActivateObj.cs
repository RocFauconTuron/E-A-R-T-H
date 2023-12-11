using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "new TriggerNode", menuName = "Dialogue/Triggers/ActivateObj", order = 0)]
public class ActivateObj : TriggerNode, iHaveNextNode
{
    public bool _bobina;
    public bool _refrigeracion;
    public bool _lore;


    public override void Trigger()
    {
        if (_bobina)
        {
            FindObjectOfType<HasObjectToEnd>().bobina = _bobina;
        }
        if(_refrigeracion)
        {
            FindObjectOfType<HasObjectToEnd>().refrigeracion = _refrigeracion;
        }
        if (_lore)
        {
            FindObjectOfType<HasObjectToEnd>().lore = _lore;
        }
    }   

    [SerializeField, Header("Next Node: (null) => EndNode")]
    private BaseNode nextDialogNode;
    public BaseNode nextNode { get => nextDialogNode; set { value = nextDialogNode; } }
}
