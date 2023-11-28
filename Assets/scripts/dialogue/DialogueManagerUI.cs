using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManagerUI : MonoBehaviour
{
    [SerializeField] Animator blackBarUp;
    [SerializeField] Animator blackBarDown;
    public BaseNode _node;
    [SerializeField] GameObject canvasDialogue;
    [SerializeField] GameObject canvasWorld;
    [SerializeField] FadeFX fade;
    [SerializeField] float fadeInTime;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void StartDialogue(BaseNode externalNode)
    {
        _node = externalNode;
        fade.FadeIn(1f);
        StartCoroutine(ShowDialogue());
    }
    IEnumerator ShowDialogue()
    {
        yield return new WaitForSeconds(fadeInTime + 1);
        fade.FadeOut(0.2f);
        blackBarUp.SetBool("isDialogue", true);
        blackBarDown.SetBool("isDialogue", true);
        canvasDialogue.SetActive(true);
        canvasWorld.SetActive(false);
        DialogManager.instance.startDialog(_node);
    }
}
