using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    private int charsToPlay = 3;

    public Button button1;
    public Button button2;

    bool canStartDialogue = false;

    [SerializeField]subDialogueManager subDialogue1;
    [SerializeField] subDialogueManager subDialogue2;
    int startNumSubDialogue1;
    int endNumSubDialogue1;
    int startNumSubDialogue2;
    int endNumSubDialogue2;

    Color panelColor;

    [SerializeField] GameObject textPanel;

    private void Start()
    {
        panelColor = new Color(0, 0, 0, 0.7f);
            
    }

    public void StartDialogue(Dialogue dialogue,int startNum, int endNum)
    {
        StartCoroutine(TypeSentence(dialogue,startNum, endNum));       
    }
    IEnumerator TypeSentence(Dialogue dialogue, int startNum, int endNum)
    {
        float time = 0;
        while (time < .5)
        {
            textPanel.GetComponent<Image>().color = Color.Lerp(textPanel.GetComponent<Image>().color, panelColor, 6f * Time.deltaTime);
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        textPanel.GetComponent<Image>().color = panelColor;

        for (int i = startNum; i <= endNum; i++)
        {
            animator.SetBool("IsOpen", true);
            dialogueText.text = dialogue.dialogues[i].speakers + ": " + dialogue.dialogues[i].sentences;
          
            yield return new WaitForSeconds(dialogue.dialogues[i].time);
            if (dialogue.dialogues[i].textType == TextType.desicion)
            {
                button1.gameObject.SetActive(true);
                button2.gameObject.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;

                startNumSubDialogue1 = dialogue.dialogues[i].subDialogueStart1;
                startNumSubDialogue2 = dialogue.dialogues[i].subDialogueStart2;
                endNumSubDialogue1 = dialogue.dialogues[i].subDialogueEnd1;
                endNumSubDialogue2 = dialogue.dialogues[i].subDialogueEnd2;

                yield return new WaitUntil(() => canStartDialogue);
                canStartDialogue = false;            
            }
            animator.SetBool("IsOpen", false);
            yield return new WaitForSeconds(.8f);
        }
        time = 0;

        while (time < .5)
        {
            textPanel.GetComponent<Image>().color = Color.Lerp(textPanel.GetComponent<Image>().color, new Color(0,0,0,0), 6f * Time.deltaTime);
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        textPanel.GetComponent<Image>().color = new Color(0,0,0,0);
    }
    public void PressButton1()
    {
        Time.timeScale = 1;
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(TypeSubDialogue(subDialogue1,startNumSubDialogue1,endNumSubDialogue1));
    }
    public void PressButton2()
    {
        Time.timeScale = 1;
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(TypeSubDialogue(subDialogue2, startNumSubDialogue2, endNumSubDialogue2));
    }

    IEnumerator TypeSubDialogue(subDialogueManager subDialogue ,int startNum, int endNum)
    {
        animator.SetBool("IsOpen", false);
        yield return new WaitForSeconds(1f);
        for (int i = startNum; i <= endNum; i++)
        {
            animator.SetBool("IsOpen", true);
            dialogueText.text = subDialogue.dialogue.dialogues[i].speakers + ": " + subDialogue.dialogue.dialogues[i].sentences;
            yield return new WaitForSeconds(subDialogue.dialogue.dialogues[i].time);
            animator.SetBool("IsOpen", false);
            yield return new WaitForSeconds(1f);
        }
        canStartDialogue = true;
    }

    //public void DisplayNextSentence()
    //{
    //    if (sentences.Count == 0)
    //    {
    //        EndDialogue();
    //        return;
    //    }

    //    string sentence = sentences.Dequeue();
    //    //StopAllCoroutines();
    //    //StartCoroutine(TypeSentence(sentence));
    //}

    //public void DisplayNextSpeaker()
    //{
    //    if (speakers.Count == 0)
    //    {
    //        EndDialogue();
    //        return;
    //    }

    //    string speaker = speakers.Dequeue();
    //    if (speaker == "Sollaid")
    //    {
    //        dialogueText.color = new Color(0f, 0f, 1.0f, 1.0f);
    //    }
    //    else
    //    {
    //        dialogueText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    //    }
    //}
}
