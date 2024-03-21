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
    
    // Update is called once per frame
    void Update()
    {
        LetsJump();
        LetsDown();
        

        timer -= Time.deltaTime;
    }

    private void LetsJump()
    {
        if ((!Input.GetButton("Jump") && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.Return) && !Input.GetKey(KeyCode.W)) ||
            !isInFloor || !(timer <= 0)) return;
        rb.AddForce(Vector2.up * force);
        timer = countDown;
    }

    private void LetsDown()
    {
        if ((Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift)||Input.GetKey(KeyCode.S) )&& !isInFloor && canDown)
        {
            rb.AddForce(Vector2.down * forceDown*Time.deltaTime,ForceMode2D.Impulse);
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
