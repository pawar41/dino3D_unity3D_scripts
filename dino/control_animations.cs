using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_animations : MonoBehaviour
{
    private Animator dino_animator;

    void Start()
    {   // access animator component
        dino_animator = GetComponent<Animator>();

        //stop running, jumping & die animations
        dino_animator.SetBool("run", false);
        dino_animator.SetBool("jump", false);
        dino_animator.SetBool("die", false);

        //test run state // intended for start button
        dino_animator.SetBool("run", true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {   // jump dino
            dino_animator.SetBool("run", false);
            dino_animator.SetBool("jump", true);
        } else { // run dino
            dino_animator.SetBool("run", true);
            dino_animator.SetBool("jump",false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {   // jump dino tmp test
            dino_animator.SetBool("run", false);
            dino_animator.SetBool("jump", false);
        } 
    }
}
