using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefCap1 : MonoBehaviour
{
    [SerializeField] private int coins = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WinObj"))
        {
            Destroy(other.gameObject);
            coins++;
            if (coins >= 4)
            {
                Levels._sharedInstance.Win();
            }
        }
    }
}
