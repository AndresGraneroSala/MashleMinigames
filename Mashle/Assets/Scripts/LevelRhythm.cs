using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRhythm : MonoBehaviour
{
    [SerializeField] private GameObject bar;
    [SerializeField] private SpriteRenderer barSprite;
    [SerializeField] private float timer=10.1f;
    [SerializeField] private float speed=0.5f;

    [SerializeField] private float startTimer=4, clickAdd=0.8f;
    
    public float Timer
    {
        get => timer;
        set => timer = Mathf.Clamp(value, 0, 10.1f);
    }

    private List<GameObject> _cracks;

    private void Start()
    {
        _cracks = new List<GameObject>();
        
        foreach (Transform crack in transform)
        {
            _cracks.Add(crack.gameObject);
            crack.gameObject.SetActive(false);
        }
        
        _cracks[0].SetActive(true);

        timer = startTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime*speed;
        bar.transform.localScale = new Vector3(timer,0.7f,1);

        if (timer<=0)
        {
            Levels._sharedInstance.Loose();
        }

        if (timer>=10)
        {
            Levels._sharedInstance.Win();
        }

        if (timer<=5f)
        {
            if (timer <= 2.5f)
            {
                barSprite.color= Color.red;
                return;
            }
            
            barSprite.color=new Color(255,165,0);
        }
        else
        {
            barSprite.color= Color.white;
        }

    }

    public void NextCrack()
    {
        _cracks[0].SetActive(false);
        _cracks.Add(_cracks[0]);
        
        _cracks.Remove(_cracks[0]);
        _cracks[0].SetActive(true);
            
        Timer += clickAdd;

    }

    
}
