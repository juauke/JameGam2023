using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] private GameObject character;
    private void OnTriggerExit2D(Collider2D other)
    {
        //desactivate the character if he exit the map/ the collider
        if (other.gameObject.CompareTag("Player"))
        {
            if (Level.isTP)
            {
                Level.isTP = false;
                return;
            }
            if (TeleportPlayer.isTP)
            {
                TeleportPlayer.isTP = false;
                return;
            }
            character.SetActive(false);
        }
    }
}
