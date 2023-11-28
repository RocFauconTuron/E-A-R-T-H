using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButonForDialogue : MonoBehaviour
{
    public BaseNode _node;
    [SerializeField] DialogueManagerUI dialogue; 
    public void ButtonPresse()
    {
        dialogue.StartDialogue(_node);
    }
}
