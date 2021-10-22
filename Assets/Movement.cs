using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float MoveSpeed = 2;
    public float SteerSpeed = 300;
    public float BodySpeed = 0.1f;
    public int Gap = 30;
    public Camera camera;



    public List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();


    void Start()
    {
        camera = Camera.main;
    }


    void Update()
    {

        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            //if(Input.mousePosition.x != transform.position.x)
            //{
            //    transform.position = Vector3.MoveTowards(transform.position,new Vector3(Input.mousePosition.x-127.5f, 0,0) , Time.deltaTime * SteerSpeed);
            //    float steerDirection = Input.mousePosition.x - 127.5f;
            //    transform.Rotate(Vector3.up * steerDirection / 2 * SteerSpeed * Time.deltaTime);
            //    if(Input.mousePosition.x-127.5f == transform.position.x)
            //    {
            //        transform.position = new Vector3(1,0,0) * MoveSpeed * Time.deltaTime;
            //    }
            //}
            //else
            //{
            //    transform.Rotate(Vector3.up * 0 * SteerSpeed * Time.deltaTime);
            //}
            Controls();

        }


        PositionsHistory.Insert(0, transform.position);


        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Min(index * Gap, PositionsHistory.Count - 1)];


            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;


            body.transform.LookAt(point);

            index++;
        }
    }

    public void Controls()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, 0, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.point.x != transform.position.z)
            {
                transform.position += transform.forward * MoveSpeed * Time.deltaTime*4;
                transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * SteerSpeed*4);
            }
          
        }
    }
}