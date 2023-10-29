using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float timeToComplete;
    public float timeLeft;
    
    [SerializeField] private Material material;
    [SerializeField] private CompositeCollider2D collider;
    private void Start()
    {
        timeLeft = 0;
    }
    
    //change the cutoff height of the DecayOfMap material to make the map disappear
    private void Update()
    {
        timeLeft += Time.deltaTime;
        if (timeLeft >= timeToComplete)
        {
            timeLeft = timeToComplete; // deadge
        }
        var cutoff = timeLeft / timeToComplete;
        material.SetFloat("_CutoffHeight", cutoff*120 - 20 );
        //augment the collider size to make the player die if he is on the map when it disappear
        collider.offset = new Vector2(cutoff*120, collider.offset.y);
    }

    void OnApplicationQuit()
    {
        material.SetFloat("_CutoffHeight", - 40);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.SetActive(false);
        }
    }
}
