using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addrope : MonoBehaviour
{
    [SerializeField] private UIrope uiRope;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //check if the player is in the trigger
        if (other.CompareTag("Player"))
        {
            uiRope.AddRope();
            Destroy(gameObject);
        }
    }
}
