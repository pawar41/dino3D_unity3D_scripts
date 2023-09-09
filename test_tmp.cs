using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_tmp : MonoBehaviour
{
    //public variable
    Rigidbody tmp_rb;
    public float m_Thrust = 20f;
    public float jump_offset = 10f;
    public float leg_offset = 1f;
    public float acceleration_run = 1f;
    public bool run_forward = true;






    //private script variables
    private Animator dino_animator;
    bool run_dino = true;

    bool jumping = false;
    Vector3 tmp_position = Vector3.zero;






    // Start is called before the first frame update
    void Start()
    {
        tmp_rb = GetComponent<Rigidbody>();

        tmp_position = new Vector3(24.29f,2.52f,-90.79f);
        transform.position = tmp_position;

        // access animator component
        dino_animator = GetComponent<Animator>();

        //stop running, jumping & die animations
        dino_animator.SetBool("run", false);
        dino_animator.SetBool("jump", false);
        dino_animator.SetBool("die", false);

        //test run state // intended for start button
        dino_animator.SetBool("run", true);
        
    }

   void FixedUpdate()
    {
        if (run_forward)
        {
            transform.position = transform.position - new Vector3(0f, 0f, Time.deltaTime * acceleration_run);
        }


        if (run_dino){
            dino_animator.SetBool("run", true);
            dino_animator.SetBool("jump",false);

            run_dino = false;
        }

        if (Input.GetButton("Jump") && !jumping && transform.position.y <= (tmp_position.y + leg_offset))
        {
            jumping = true;
            tmp_position = transform.position;

            dino_animator.SetBool("jump", true);
            dino_animator.SetBool("run", false);

        }
        
        if (jumping && transform.position.y < tmp_position.y + jump_offset ){
            tmp_rb.AddForce(transform.up * m_Thrust);
        } else if (jumping){
            jumping = false;
        } 
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground_green" || collision.gameObject.tag == "ground_tan")
        {
            run_dino = true;
        }
    }
}
