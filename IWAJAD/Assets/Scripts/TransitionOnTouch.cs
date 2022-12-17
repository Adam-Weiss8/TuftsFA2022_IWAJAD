using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionOnTouch : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Found player");
            StartCoroutine(Transition());
        }
    }

    IEnumerator Transition()
    {
        // You can use a built-in Unity function to fade to black over the course of a given time
        yield return StartCoroutine(FadeToBlack(1.0f));

        // Load the new scene
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeToBlack(float time)
    {
        // Set up the fade
        float elapsedTime = 0.0f;
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.0f;
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0.0f, 1.0f, elapsedTime / time);
            yield return null;
        }
    }
}
