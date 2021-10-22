using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        if (transform.position.x != 0)
        {
            float rotz = transform.position.z;
            float rotY = transform.position.y;
            transform.position = new Vector3(0, rotY, rotz);
        }
    }
}
