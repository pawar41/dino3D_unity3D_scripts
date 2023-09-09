using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follower : MonoBehaviour
{
    public GameObject player;
    public Vector3 offsetPositon = new Vector3(1f, -3f, -6f);
    public Vector3 offsetRotation = new Vector3(0f, 180f, 0);


    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position - offsetPositon;
        transform.eulerAngles = offsetRotation;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position - offsetPositon;
        transform.eulerAngles = offsetRotation;

    }
}
