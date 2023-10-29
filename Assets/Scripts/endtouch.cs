using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endtouch : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private bool _isEnd;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(_isEnd) return;
        playerController.endGame=true;
    }
}
