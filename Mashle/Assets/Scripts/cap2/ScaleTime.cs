using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTime : MonoBehaviour
{
    [SerializeField] private Vector3 scale;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= scale*speed*Time.deltaTime;
    }
}
