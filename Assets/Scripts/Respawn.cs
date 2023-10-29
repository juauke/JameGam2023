using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject character;
    private bool _isRespawning;
    [SerializeField] LevelTimer levelTimer;
    private void Update()
    {
        if (!character.activeSelf && !_isRespawning)
        {
            _isRespawning = true;
            StartCoroutine(RespawnCharacter());
        }
    }
    
    IEnumerator RespawnCharacter()
    {
        yield return new WaitForSeconds(3);
        levelTimer.timeLeft = 0;
        character.SetActive(true);
        character.transform.position = transform.position;
        _isRespawning = false;
    }
}
