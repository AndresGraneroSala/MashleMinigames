using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Jump : MonoBehaviour
{
    [SerializeField] private float force,countDown,timer=0;
    [SerializeField] private bool isJumping,isInFloor,canDown;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float forceDown;
    [SerializeField] private bool isTouchJumping, isTouchDowning;
    
    // Update is called once per frame
    void Update()
    {
        LetsJump();
        LetsDown();
        

        timer -= Time.deltaTime;
    }

    private void LetsJump()
    {
        if (isTouchJumping &&
            (Input.GetButtonUp("Jump") || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Return) ||
             Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.W)||Input.GetMouseButtonUp(0) ))
        {
            isTouchJumping = false;
        }


        if ((!Input.GetButton("Jump") && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.Return) && !Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.W)&& !Input.GetMouseButtonDown(0))  ||
            !isInFloor || !(timer <= 0)|| isTouchDowning) return;
        rb.AddForce(Vector2.up * force);
        timer = countDown;
        isTouchJumping = true;
    }

    private void LetsDown()
    {
        if (isTouchDowning&& 
            ((Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift) ||
              Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.Mouse0)|| Input.GetMouseButtonUp(0))))
        {
            isTouchDowning = false;
        }
        
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ||
             Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Mouse0)|| Input.GetMouseButtonDown(0))
            && !isInFloor && canDown &&!isTouchJumping)
        {
            rb.AddForce(Vector2.down * forceDown * Time.deltaTime, ForceMode2D.Impulse);
            isTouchDowning = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.CompareTag("Floor"))
        {
            isInFloor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isInFloor = false;
    }
}
