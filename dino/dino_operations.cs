using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_properties_add : MonoBehaviour
{
    public GameObject parentGameobject;
    Rigidbody tempRigidBody;
    MeshCollider tmpmeshCollider;
    public bool rocks_setting = true;
    //public bool cactus_setting = false;


public int getChildren(GameObject obj){
        int count = 0;

        for (int i = 0; i < obj.transform.childCount; i++)
        {
            count++;
            //counter(obj.transform.GetChild(i).gameObject, ref count);
        }
        return count;
    }

    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < transform.childCount; i++){
            if(parentGameobject.transform.GetChild (i).gameObject.GetComponent<Rigidbody>() == null) {
                //Debug.Log("child " + i);
                tempRigidBody = parentGameobject.transform.GetChild (i).gameObject.AddComponent<Rigidbody>();
            }  else {
                tempRigidBody = parentGameobject.transform.GetChild (i).gameObject.GetComponent<Rigidbody>() ;
            }
            tempRigidBody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX ;
            //tempRigidBody.isKinematic = true;

            if( rocks_setting ){
                tmpmeshCollider = parentGameobject.transform.GetChild (i).gameObject.GetComponent<MeshCollider>();

            // settings for rock
                tmpmeshCollider.convex = true;
                tmpmeshCollider.providesContacts = true;
            }

            /*if( cactus_setting){
                tmpmeshCollider = parentGameobject.transform.GetChild (i).gameObject.GetComponent<MeshCollider>();

            // settings for rock
                tmpmeshCollider.convex = true;
                tmpmeshCollider.providesContacts = true;
            }*/

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
