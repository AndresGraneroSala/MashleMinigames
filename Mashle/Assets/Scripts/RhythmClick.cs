using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmClick : MonoBehaviour
{
    private LevelRhythm _levelRhythm;
    private void Start()
    {
        _levelRhythm = FindObjectOfType<LevelRhythm>();
    }

    private void OnMouseOver()
    {
        if (Input.anyKey)
        {
            _levelRhythm.NextCrack();
        }
    }
}
