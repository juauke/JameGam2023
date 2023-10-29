using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = ": 0";
    }

    // Update is called once per frame
    public void UpdateCount(int n)
    {
        text.text = ": " + n;
    }
}