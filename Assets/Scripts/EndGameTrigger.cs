using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    public CinematicText[] cinematicTexts;
    private int currentTextIndex;
    
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTriggered && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayCinematic());
            hasTriggered = true;
        }
    }
    
    IEnumerator PlayCinematic()
    {
        while (currentTextIndex < cinematicTexts.Length)
        {
            cinematicTexts[currentTextIndex].gameObject.SetActive(true);
            yield return new WaitForSeconds(cinematicTexts[currentTextIndex].delay); // Réglez la durée d'affichage du texte

            cinematicTexts[currentTextIndex].gameObject.SetActive(false);
            currentTextIndex++;

            if (currentTextIndex < cinematicTexts.Length)
            {
                yield return new WaitForSeconds(0.5f); // Réglez le délai entre les textes
            }
        }
    }
}
