using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CinematicManager : MonoBehaviour
{
    public CinematicText[] cinematicTexts;
    private int currentTextIndex = 0;
    
    void Start()
    {
        StartCoroutine(PlayCinematic());
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



