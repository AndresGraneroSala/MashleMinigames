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

    [SerializeField] private GameObject[] numbers;

    [SerializeField] private GameObject sad;

    [SerializeField] private Color orange;
    
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
        
        

        timer = startTimer;

        StartCoroutine(CountDown());

    }

    private IEnumerator CountDown()
    {
        _cracks[0].GetComponent<CircleCollider2D>().enabled = false;
        _cracks[0].SetActive(true);
        
        yield return new WaitForSeconds(1);
        numbers[0].SetActive(true);
        yield return new WaitForSeconds(1);
        numbers[1].SetActive(true);
        yield return new WaitForSeconds(1);
        numbers[2].SetActive(true);
        
        _cracks[0].GetComponent<CircleCollider2D>().enabled = true;
        
        yield return new WaitForSeconds(1);
        
        numbers[0].SetActive(false);
        numbers[1].SetActive(false);
        numbers[2].SetActive(false);

    }
    

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime*speed;
        

        if (timer<=0f)
        {
            sad.SetActive(true);
            return;
        }

        if (timer>=10)
        {
            Levels._sharedInstance.Win();
        }

        if (timer<=5f)
        {                
            barSprite.color=orange;

            if (timer <= 2.5f)
            {
                barSprite.color= Color.red;
            }
            else
            {
            }
            
        }
        else
        {
            barSprite.color= Color.white;
        }
        bar.transform.localScale = new Vector3(timer,0.7f,1);

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
