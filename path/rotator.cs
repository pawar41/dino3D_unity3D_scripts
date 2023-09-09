using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{   
    private Vector3 rotate_sphere = new Vector3 (1f,0f,0f);
    public float acceleration_rotation = 0.1f;

    void Update()
    {
        rotate_sphere.x = acceleration_rotation + rotate_sphere.x * Time.deltaTime;
        transform.Rotate(rotate_sphere);
        //cube2.transform.Rotate(xAngle, yAngle, zAngle, Space.World);
    }
}
