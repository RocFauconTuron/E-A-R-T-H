using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneButton : MonoBehaviour
{
    public string sceneName;
    [SerializeField] FadeFX fade;
    [SerializeField] float fadeInTime;
    public void ChangeLevel(string name)
    {
        fade.FadeIn(1f);
        sceneName = name;
        StartCoroutine(ShowDialogue());
    }
    IEnumerator ShowDialogue()
    {
        yield return new WaitForSeconds(fadeInTime + .5f);
        SceneManager.LoadScene(sceneName);
    }
}
