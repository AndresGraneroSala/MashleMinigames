using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadCap1P1 : MonoBehaviour
{
    [SerializeField] private GameObject sad;

    [SerializeField] private float timer,countDown=3;

    [SerializeField] private bool coinTrap=false;


    private void Update()
    {
        if (coinTrap)
        {
            timer += Time.deltaTime;

            if (timer >= countDown)
            {
                sad.SetActive(true);
            }
        }
        
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("WinObj"))
        {
            coinTrap = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("WinObj"))
        {
            coinTrap = false;
            timer = 0;
        }
    }
}
