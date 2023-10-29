using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static  bool isTP;
    [SerializeField] private Transform Checkpoint;
    [SerializeField] private Transform nextCheckpoint;
    [SerializeField] private LevelTimer levelTimer;
    [SerializeField] private UIrope uiRope;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            uiRope.numberRopes = 0;
            levelTimer.timeLeft = 0;
            var nextPos = nextCheckpoint.position;
            collision.gameObject.transform.position = nextPos;
            Checkpoint.position = nextPos;
            isTP = true;
            // faire des animations quand on spawn plus loin ?
        }
    }
}