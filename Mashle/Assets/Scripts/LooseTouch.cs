using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("LooseObj"))
        {
            Levels.Loose();
        }
    }
}
