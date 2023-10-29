using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematicText : MonoBehaviour
{
    public Text textComponent;
    public string cinematicText;
    public float delay;

    void Start()
    {
        textComponent.text = "";
        Invoke("DisplayText", delay);
    }

    void DisplayText()
    {
        textComponent.text = cinematicText;
    }
}
