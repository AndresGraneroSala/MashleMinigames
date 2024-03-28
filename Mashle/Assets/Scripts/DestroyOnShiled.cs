using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnShiled : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
    }
}
