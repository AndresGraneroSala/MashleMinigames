using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleNextScene : MonoBehaviour
{
    [SerializeField] private List< GameObject> images;
    [SerializeField] private int countImg=0;

    [SerializeField] private Transform parentImages;
    
    private void Awake()
    {
        foreach (Transform image in parentImages)
        {
            images.Add(image.gameObject);
        }
        
        countImg = -1;
        Next();
    }

    public void Next()
    {
        countImg++;

        if (countImg>=images.Count)
        {
            Levels._sharedInstance.Win();
            return;
        }
        
        for (int i = 0; i < images.Count; i++)
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
