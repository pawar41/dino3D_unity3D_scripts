using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physics : MonoBehaviour
{
    public float acceleration_run = 1f;
    public float leg_offset =1f;
    public Vector3 jump_offset = new Vector3(0f, 10f, -8.39f);
    bool run_forward = true;
    public Vector3 initial_position = new Vector3(24f, 6f,-38f);
    public float tan_jump_angle = 1.191f;
    public float tan_jump_adj = 8.39f;

 

    bool jumping = false;
    bool acend = false;
    bool decend = false;


    Vector3 tmp, tmp2, tmp3;
    Vector3 dino_position;
    public Rigidbody rb;
    void Start()
    {
        transform.position = initial_position;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        dino_position = transform.position;

        if(run_forward) {
            transform.position = transform.position - new Vector3(0f, 0f , Time.deltaTime * acceleration_run);
        }

        if (!jumping && ( Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && ( transform.position.y < dino_position.y +leg_offset ) ) {   
            // jump dino
            rb.useGravity = false;
            jumping = true;
            acend = true;
            decend = false;

            tmp = transform.position;
            //tmp2.z = tmp.z;
        }

        if (jumping) {
            if(acend && ((transform.position.y < tmp.y + jump_offset.y) && (transform.position.z > tmp.z + jump_offset.z) )) { // 
                tmp2.z = tmp.z - transform.position.z;
                
                if( tmp2.z == 0f ){
                    tmp2.z = 0.01f;
                }
                
                if ( tmp2.z < 0f ){
                    tmp2.z = -tmp2.z;
                }

                // testing for bug ACEND
                //transform.position = transform.position + new Vector3(0f, tan_jump_angle * tmp2.z , 0f);
                transform.position = new Vector3(transform.position.x, tan_jump_angle * tmp2.z , transform.position.z);

                // bug test : passed
                //Debug.Log("hello acending " + transform.position.z + " | " +  (tmp.z + jump_offset.z));
                    
            } else if(acend){
                acend = false;
                decend = true;
                //tmp = transform.position;
                //bug test : passed

                Debug.Log("Repeated else bug");
            }

            
            if(decend && ((transform.position.y > tmp.y - (jump_offset.y - leg_offset)) && (transform.position.z > tmp.z + jump_offset.z) )) { // 
                tmp2.z = tmp.z - transform.position.z;

                if ( tmp2.z < 0f ){
                    tmp2.z = -tmp2.z;
                }

                tmp3.z = (tmp.z + jump_offset.z ) - tmp2.z;

                if ( tmp3.z < 0f ){
                    tmp3.z = -tmp3.z;
                }
                // testing for bug ACEND
                //transform.position = transform.position + new Vector3(0f, tan_jump_angle * tmp3.z , 0f);
                transform.position = new Vector3(transform.position.x, tan_jump_angle * tmp3.z , transform.position.z);

                //Debug.Log("hello decending " + (tan_jump_angle * tmp3.z));
                //Debug.Log("decend " + (transform.position.z > tmp.z + jump_offset.z) );


            } else if(decend){
                decend = false;
                //tmp = Vector3.zero;
                //tmp2 = Vector3.zero;
                //tmp3 = Vector3.zero;
                //rb.useGravity = true;

                //jumping = false;
                Debug.Log("only once else");
            }   
        }

        if (dino_position.y > 38f || dino_position.y < -15f ){
            transform.position = initial_position;
        }

    }


    /*void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "MyGameObjectName")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "MyGameObjectTag")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }

        Debug.Log(collision.gameObject.name);
    }
    */
        
    
}
