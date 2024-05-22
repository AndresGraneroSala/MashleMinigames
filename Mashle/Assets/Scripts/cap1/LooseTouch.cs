using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseTouch : MonoBehaviour
{
    [SerializeField] private GameObject mashleSad;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("LooseObj"))
        {
            mashleSad.SetActive(true);
            Time.timeScale = 0;
            
        }
    }
}
