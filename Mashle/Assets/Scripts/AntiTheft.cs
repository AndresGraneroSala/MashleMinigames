using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntiTheft : MonoBehaviour
{
    private static readonly string[] Urls = new string[] {"https://mashle-minigames.vercel.app/" };

    [SerializeField] private Text texto;
    
    // Start is called before the first frame update
    void Awake()
    {
        //Debug.Log(Application.absoluteURL);
        //texto.text = Application.absoluteURL;

        bool isTheft = true;
        
        for (int i = 0; i < Urls.Length; i++)
        {
            if (Urls[i]== Application.absoluteURL)
            {
                isTheft = false;
            }
        }

        if (isTheft)
        {
            texto.color=Color.red;
            texto.text = "This game has been stolen, it belongs to shiny games";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
