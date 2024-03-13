using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleNextScene : MonoBehaviour
{
    [SerializeField] private GameObject [] images;
    [SerializeField] private int countImg=0;

    private void Awake()
    {
        countImg = -1;
        Next();
    }

    public void Next()
    {
        countImg++;

        if (countImg>=images.Length)
        {
            Levels._sharedInstance.Win();
            return;
        }
        
        for (int i = 0; i < images.Length; i++)
        {
            if (i == countImg)
            {
                images[i].SetActive(true);
            }
            else
            {
                images[i].SetActive(false);
            }
            
        }
        
    }
}
