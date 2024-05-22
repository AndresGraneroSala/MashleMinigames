using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSimple : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction*speed*Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        
        Gizmos.DrawRay(transform.position, direction*10);
    }
}
