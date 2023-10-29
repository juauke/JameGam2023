using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addrope : MonoBehaviour
{
    [SerializeField] private Respawn respawn;
    [SerializeField] private UIrope uiRope;
    //[SerializeField] private GameObject child;
    [SerializeField] private Collider2D collider2D;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //check if the player is in the trigger
        if (other.CompareTag("Player"))
        {
            uiRope.AddRope();
            collider2D.enabled = false;
            spriteRenderer.enabled = false;
        }
    }

    private void Update()
    {
        if (respawn._isRespawning)
        {
            collider2D.enabled = true;
            spriteRenderer.enabled = true;
        }
    }
}
