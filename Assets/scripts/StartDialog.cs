using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog : MonoBehaviour
{
    public Dialogue dialogue;
    public int time;
    public GravityObjectController goc;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, 0, dialogue.dialogues.Count - 1);
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        goc.gameObject.SetActive(true);
    }
}
