using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public List<DialogueObject> dialogues;
}
[System.Serializable]
public class DialogueObject
{
    [TextArea(3, 10)]
    public string sentences;
    public string speakers;
    public float time;
    public TextType textType;
    public int subDialogueStart1;
    public int subDialogueEnd1;
    public int subDialogueStart2;
    public int subDialogueEnd2;
}
public enum TextType
{
    normal, desicion
}
