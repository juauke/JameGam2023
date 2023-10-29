using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject character;
    private bool _isRespawning;
    [SerializeField] LevelTimer levelTimer;
    [SerializeField] private StressBar stressBar;
    [SerializeField] private ViewField viewField;
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
        viewField.isDying = false;
        stressBar.enabled = false;
        yield return new WaitForSeconds(3);
        stressBar.enabled = true;
        stressBar._stress = 0;
        levelTimer.timeLeft = 0;
        character.SetActive(true);
        character.transform.position = transform.position;
        _isRespawning = false;
    }
}
