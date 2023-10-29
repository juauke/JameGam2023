using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIrope : MonoBehaviour
{
    [SerializeField] public int numberRopes;
    [SerializeField] private TextMeshProUGUI ropeText;
    
    public void AddRope()
    {
        numberRopes++;
    }
    private void Update()
    {
        ropeText.text = ":"+numberRopes;
    }
}
