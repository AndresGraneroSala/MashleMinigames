using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CoinCap1 : MonoBehaviour
{
    [SerializeField] private float force = 5;

    private Rigidbody2D _rb;

    [SerializeField] private bool isOnClick = false;
    

    [SerializeField] private GameObject arrow;

    [SerializeField] private bool isInFloor=false;

    [SerializeField] private GameObject sad;
    
    private Vector2 DirMouse()
    {
        Vector2 dir = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return dir;
    }
    
    
    
    // Start is called before the first frame update
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        arrow.SetActive(false);

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _rb.AddForce(transform.up*force, ForceMode2D.Force);
        }

        if (isOnClick && !Input.GetKey(KeyCode.Mouse0))
        {
            isOnClick = false;
            Throw();
            
        }

       if (isOnClick)
        {
            // LookAt 2D

// get the angle
            Vector3 norTar = DirMouse().normalized;
            float angle = Mathf.Atan2(norTar.y,norTar.x)*Mathf.Rad2Deg;

// rotate to angle
            Quaternion rotation = new Quaternion ();
            rotation.eulerAngles = new Vector3(0,0,angle-90);
            arrow.transform.rotation = rotation;

            float distanceY = transform.position.y-Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

            float distance = Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

            arrow.transform.localScale = new Vector3(arrow.transform.localScale.x, distance*1.2f,arrow.transform.localScale.z);
        }

        if (Mathf.Abs(transform.position.x) > 10 ||Mathf.Abs(transform.position.y) > 7 )
        {
            sad.SetActive(true);
        }


    }
    private void OnMouseDown()
    {
        if (!isInFloor)
        {
            return;
        }
        
        isOnClick = true;
        arrow.SetActive(true);
    }
    

    private void Throw()
    {       
        arrow.SetActive(false);
        _rb.AddForce(DirMouse()*force, ForceMode2D.Force);

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Floor"))
        {
            isInFloor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isInFloor = false;
    }
}
