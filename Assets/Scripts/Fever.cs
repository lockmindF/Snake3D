using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fever : MonoBehaviour
{
    public float MoveSpeed = 14;
    bool feverMode = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (feverMode == true)
        {
            transform.position -= transform.forward * MoveSpeed * Time.deltaTime;
        }
    }
    public void FeverModeOn()
    {
        feverMode = true;
    }
    public void FeverModeOff()
    {
        feverMode = false;
    }
}
