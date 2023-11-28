using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnWorldDialogue : MonoBehaviour
{
    [SerializeField] Animator blackBarUp;
    [SerializeField] Animator blackBarDown;
    [SerializeField] GameObject canvasWorld;
    [SerializeField] FadeFX fade;
    [SerializeField] float fadeOutTime;
    public void DialogueEnded()
    {
        blackBarUp.SetBool("isDialogue", false);
        blackBarDown.SetBool("isDialogue", false);
        StartCoroutine(ShowWorld());
    }
    IEnumerator ShowWorld()
    {
        yield return new WaitForSeconds(0.3f);
        fade.FadeIn(.2f);
        yield return new WaitForSeconds(1.2f);
        fade.FadeOut(fadeOutTime);
        canvasWorld.SetActive(true);
    }
}
