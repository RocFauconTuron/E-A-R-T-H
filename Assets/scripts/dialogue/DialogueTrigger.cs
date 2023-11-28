using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, 0, dialogue.dialogues.Count - 1);
            Destroy(gameObject);
        }
    }
}
