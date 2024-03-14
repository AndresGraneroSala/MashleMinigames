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
        SceneManager.LoadScene(levels[actualLevel]);

    }

    public void Loose()
    {
        SceneManager.LoadScene(levels[actualLevel]);
    }

    private void SetMenu()
    { 
        //GameObject menuInst= Instantiate(menu);
        //DontDestroyOnLoad(menuInst);
        //menuInst.GetComponentInChildren<Button>().onClick.AddListener(Loose);
    }
}
