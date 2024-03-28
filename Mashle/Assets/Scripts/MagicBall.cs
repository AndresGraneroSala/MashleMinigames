using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shield"))
        {
            //Destroy(gameObject);

            transform.position = startPosition;
            
            
            FindObjectOfType<LevelRhythm>().NextCrack();
            
            gameObject.SetActive(false);
            
        }
    }
}
