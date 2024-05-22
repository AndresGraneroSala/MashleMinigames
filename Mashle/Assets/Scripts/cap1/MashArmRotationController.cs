using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashArmRotationController : MonoBehaviour
{
    [SerializeField] private GameObject armJoint;
    [SerializeField] private float maxAngle,minAngle=0;
    [SerializeField] private bool isHitting = false;
    [SerializeField] private float speed=1;
    [SerializeField] private BoxCollider2D box;

    [SerializeField] private SpriteRenderer armRenderer;
    
    int direction = -1;

    [SerializeField] private float timer;
    [SerializeField] private float startTimer=0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {        
        timer -= Time.deltaTime;

        if (timer<=0)
        {
            armRenderer.color = new Color(255, 255,255, 255);
        }
        else
        {
            armRenderer.color = new Color(255, 0,2, 255);
        }
        

        if (Input.GetKeyDown(KeyCode.Mouse0)&& !isHitting && timer<=0)
        {
            isHitting = true;
            box.enabled = true;
        }

        if (isHitting)
        {
            armJoint.transform.Rotate(new Vector3(0, 0, 1) * speed * Time.deltaTime * direction);

            if (armJoint.transform.localRotation.eulerAngles.z <= maxAngle)
            {
                direction = 1;
            }

            if (direction != -1 && armJoint.transform.localRotation.eulerAngles.z >= minAngle)
            {
                direction = -1;
                armJoint.transform.localRotation = Quaternion.Euler(0, 0, 359);
                isHitting = false;
                box.enabled = false;
                timer = startTimer;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LooseObj"))
        {
            
            FindObjectOfType<LevelRhythm>().NextCrack(true);
        }
    }
}
