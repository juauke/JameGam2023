using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform Checkpoint;
    [SerializeField] private Transform nextCheckpoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            var nextPos = nextCheckpoint.position;
            collision.gameObject.transform.position = nextPos;
            Checkpoint.position = nextPos;
            // faire des animations quand on spawn plus loin ?
        }
    }
}
