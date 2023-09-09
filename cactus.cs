using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactus : MonoBehaviour
{
    int prev_anim = 0;
    int new_anim = 0;
    Animator cactus_anim;
    // Start is called before the first frame update
    void Start()
    {
        cactus_anim = gameObject.GetComponent<Animator>();
        for(int i = 1;i <= 5; i++){
            cactus_anim.SetBool(("anim" + i.ToString()), false);
        }
        cactus_anim.SetBool("dead", false);
        new_anim = Random.Range(1,5);

        while(new_anim == prev_anim){
            new_anim = Random.Range(1,5); 
            }

        cactus_anim.SetBool(("anim" + new_anim.ToString()), true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
