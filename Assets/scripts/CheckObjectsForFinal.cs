using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObjectsForFinal : MonoBehaviour
{
    public BaseNode final1;
    public BaseNode final2;
    public BaseNode final3;
    public BaseNode final4;
    [SerializeField] DialogueManagerUI dialogue;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<HasObjectToEnd>().refrigeracion && FindObjectOfType<HasObjectToEnd>().lore)
        {
            dialogue.StartDialogue(final4);
        }
        else if (FindObjectOfType<HasObjectToEnd>().refrigeracion)
        {
            dialogue.StartDialogue(final3);
        }
        else if (FindObjectOfType<HasObjectToEnd>().lore)
        {
            dialogue.StartDialogue(final2);
        }
        else
        {
            dialogue.StartDialogue(final1);
        }
    }
}
