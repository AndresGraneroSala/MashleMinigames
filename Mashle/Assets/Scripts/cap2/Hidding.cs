using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidding : MonoBehaviour
{
    [SerializeField] private float timeNoHiding=2f,timer;
    [SerializeField] private bool isHidden;

    private void Awake()
    {
        timer = timeNoHiding;
        isHidden = false;
    }

    private void Update()
    {
        if (!isHidden)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = timeNoHiding;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("WinObj"))
        {
            isHidden = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isHidden = false;
    }
}
