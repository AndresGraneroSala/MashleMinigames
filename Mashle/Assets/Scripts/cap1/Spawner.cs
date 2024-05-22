using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float minTime, maxTime;

    private float countDown;

    // Update is called once per frame
    void Update()
    {
        if (countDown<=0)
        {
            Instantiate(prefab);
            countDown = Random.Range(minTime, maxTime);
        }

        countDown -= Time.deltaTime;
    }
}
