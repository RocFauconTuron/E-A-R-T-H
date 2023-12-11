using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    public int time;
    public string sceneName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ChangeScene());
        }
    }
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(sceneName);
    }
}
