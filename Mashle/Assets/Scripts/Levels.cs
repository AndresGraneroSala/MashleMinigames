using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    [SerializeField] private string[] levels;
    [SerializeField] private int actualLevel=0;

    //public GameObject menu;
    
    public static Levels _sharedInstance;

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.W))
        {
            Win();
        }

#endif
    }


    public void StartLevels()
    {
        DontDestroyOnLoad(gameObject);
        actualLevel = 0;
        _sharedInstance = this;

        //SetMenu();        
        
        SceneManager.LoadScene(levels[0]);

    }

    public void Win()
    {
        actualLevel++;

        if (actualLevel>= levels.Length)
        {
            SceneManager.LoadScene("Menu");
            Destroy(gameObject);

        }
        else
        {
            SceneManager.LoadScene(levels[actualLevel]);
        }

    }

    static public void Loose()
    {
        print(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SetMenu()
    { 
        //GameObject menuInst= Instantiate(menu);
        //DontDestroyOnLoad(menuInst);
        //menuInst.GetComponentInChildren<Button>().onClick.AddListener(Loose);
    }
}
