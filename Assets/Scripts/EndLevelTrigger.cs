using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelTrigger : MonoBehaviour
{
    public CinematicText levelClearedText;
    public float displayDuration = 2.0f; // Durée d'affichage en secondes

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTriggered && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ShowTextForDuration());
            hasTriggered = true;
        }
    }

    IEnumerator ShowTextForDuration()
    {
        levelClearedText.gameObject.SetActive(true);

        yield return new WaitForSeconds(displayDuration);

        levelClearedText.gameObject.SetActive(false);
    }
}


