using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_tmp : MonoBehaviour
{
    //public variable
    Rigidbody tmp_rb;

    // z acceleration run : y thrust
    public float jump_multiple = 10f;


    public float jump_offset = 10f;
    public float dist_z = 15f;
    public float leg_offset = 1f;
    public float acceleration_run = 1f;
    public bool run_forward = true;
    public Vector3 initial_position = new Vector3(24.29f, 2.52f, -100.79f);
    //public float gravity_force = 10f;
    public float gravity_multiple = 6f;
    public float run_sppeed_animation_divider = 15f;







    //private script variables
    private Animator dino_animator;
    bool run_dino = true;
    bool z_check = false;

    bool jumping = false;

    
    Vector3 tmp_position = Vector3.zero;
    private float y_Thrust = 0f;







    // Start is called before the first frame update
    void Start()
    {
        y_Thrust = acceleration_run * jump_multiple;
        tmp_rb = GetComponent<Rigidbody>();

        tmp_position = initial_position;
        transform.position = initial_position;

        // access animator component
        dino_animator = GetComponent<Animator>();

        //stop running, jumping & die animations
        dino_animator.SetBool("run", false);
        dino_animator.SetBool("jump", false);
        dino_animator.SetBool("die", false);

        //test run state // intended for start button
        dino_animator.SetBool("run", true);

        //set running animation speed
        dino_animator.SetFloat("run_speed", acceleration_run / run_sppeed_animation_divider);

        
    }

   void FixedUpdate()
    {
        if (run_forward)
        {
            y_Thrust = acceleration_run * jump_multiple;

            transform.position = transform.position - new Vector3(0f, 0f, Time.deltaTime * acceleration_run);
        }

        /*

        if (objectCollider.IsTouching(anotherCollider))
        {
            // Do something;
        }
        
         */


        if (run_dino){
            dino_animator.SetBool("run", true);
            dino_animator.SetBool("jump",false);

            run_dino = false;
        }

        /*

        if(!z_check && !jumping)
        {
            // update z position data
            tmp_position.y = transform.position.y;
        } */

        if (Input.GetButton("Jump") /* button pressed */ && !jumping  /* finished jump */&& transform.position.y <= (tmp_position.y + leg_offset) /* is on ground */ )
        {
            jumping = true;
            tmp_position = transform.position;

            dino_animator.SetBool("jump", true);
            dino_animator.SetBool("run", false);
            tmp_rb.useGravity = false;

            //Debug.Log("jmping");



        }

        if (jumping /**/ && (transform.position.y < tmp_position.y + jump_offset) )
        {
            tmp_rb.AddForce(transform.up * y_Thrust);
        } else if (jumping){
            tmp_rb.velocity = Vector3.zero;
            jumping = false;
            z_check = true;
            // Debug.Log("Reached" + Time.deltaTime);
        } else if( (transform.position.z > tmp_position.z - dist_z )&& z_check)
        {
            tmp_rb.useGravity = false;
            //Debug.Log( (tmp_position.z + dist_z) + " | " + transform.position.z );
            //Debug.Log("to reach " + (tmp_position.z + dist_z) + " > is where" + transform.position.z + "      : " + (transform.position.z < dist_z + tmp_position.z));
            //Debug.Log("is exec" + transform.position.z);
        }
        else if(z_check)
        {
            tmp_rb.useGravity = true;
            z_check = false;
            tmp_rb.AddForce(transform.up * (-(gravity_multiple * acceleration_run)));
        }

        //Debug.Log("to reach " + (tmp_position.z - dist_z) + " > is where" + transform.position.z + "      : " + (transform.position.z > tmp_position.z - dist_z));


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground_green" || collision.gameObject.tag == "ground_tan")
        {
            run_dino = true;
            tmp_rb.velocity = Vector3.zero;

            tmp_position.y = transform.position.y;


        }
    }

    void LateUpdate()
    {
        dino_animator.SetFloat("run_speed", acceleration_run / run_sppeed_animation_divider);

    }

}
