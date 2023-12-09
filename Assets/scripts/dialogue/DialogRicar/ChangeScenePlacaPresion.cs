using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenePlacaPresion : MonoBehaviour
{
    public string sceneName;
    string actualScene;
    public BaseNode node;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube") || other.CompareTag("Player"))
        {
            StartCoroutine(ShowNextDialogueWhenChangeScene());
        }
    }
    IEnumerator ShowNextDialogueWhenChangeScene()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene(sceneName);
        while (SceneManager.GetActiveScene().name != sceneName)
        {
            yield return new WaitForEndOfFrame();
        }
        FindObjectOfType<DialogueManagerUI>().StartDialogue(node);
        Destroy(gameObject);
    }
}
