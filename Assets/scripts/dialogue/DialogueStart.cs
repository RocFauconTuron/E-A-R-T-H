using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueStart : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue dialogue2;
    public TextMeshProUGUI dialogueText;

    public Animator animator;
    public GameObject panel;

    [SerializeField] GameObject textPanel;

    [SerializeField] PlayerMovementTutorial playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement.enabled = false;
        panel.GetComponent<Image>().color = Color.black;
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            animator.SetBool("IsOpen", true);
            dialogueText.text = dialogue.dialogues[i].speakers + ": " + dialogue.dialogues[i].sentences;

            yield return new WaitForSeconds(dialogue.dialogues[i].time);
            animator.SetBool("IsOpen", false);
            yield return new WaitForSeconds(1.5f);
        }

        Color color = panel.GetComponent<Image>().color;
        color.a = 0;         
        float time = 0;

        textPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.7f);

        while (time < 1.5)
        {
            panel.GetComponent<Image>().color = Color.Lerp(panel.GetComponent<Image>().color, color, 1f * Time.deltaTime);
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        panel.GetComponent<Image>().color = color;

        for (int i = 0; i < dialogue2.dialogues.Count; i++)
        {
            animator.SetBool("IsOpen", true);
            dialogueText.text = dialogue2.dialogues[i].speakers + ": " + dialogue2.dialogues[i].sentences;

            yield return new WaitForSeconds(dialogue2.dialogues[i].time);
            animator.SetBool("IsOpen", false);
            yield return new WaitForSeconds(.8f);
        }
        time = 0;

        while (time < 1)
        {
            textPanel.GetComponent<Image>().color = Color.Lerp(textPanel.GetComponent<Image>().color, new Color(0, 0, 0, 0), 3f * Time.deltaTime);
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        textPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        playerMovement.enabled = true;
    }
}
