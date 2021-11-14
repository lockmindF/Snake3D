using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float MoveSpeed = 7;
    public float SteerSpeed = 7;
    public float BodySpeed = 50;
    public int Gap = 6;
    public Camera camera;
    public string color = "green";
    public GameObject body;
    public float timeRemaining = 0;
    public bool feverMode = false;
    public int diamondInRow = 0;




    public List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();


    void Start()
    {
        camera = Camera.main;
    }


    void Update()
    {
        TimeRemaining();
        MoveZ();
        BodyPart();
        
        
        if (Input.GetMouseButton(0))
        {
            Controls();

        }


        
    }
    public void BodyPart()
    {
        PositionsHistory.Insert(0, transform.position);
        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Min(index * Gap, PositionsHistory.Count - 1)];
            Debug.Log(Gap);


            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;


            body.transform.LookAt(point);

            index++;
        }
    }
    public void MoveZ()
    {

        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }
    public void TimeRemaining()
    {
        if (timeRemaining != 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                feverMode = false;
                timeRemaining = 0;
                FindObjectOfType<Fever>().FeverModeOff();
                diamondInRow = 0;
                FindObjectOfType<GameManager>().DiamondZero();
            }
        }
    }

    public void Controls()
    {
        if (!feverMode)
        {
            Ray ray = camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, 0, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.point.x != transform.position.z)
                {

                    transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z + 4));



                }

            }
        }
        
    }
    public void FeverMode()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
        transform.LookAt(new Vector3(0, transform.position.y, transform.position.z+100));
        feverMode = true;
        FindObjectOfType<Fever>().FeverModeOn();
        timeRemaining = 5;
        
        
        

    }
    

    private void OnTriggerEnter(Collider colider)
    {
        string col = colider.gameObject.tag;
        if (col == "Wall")
        {
            transform.Rotate(0.0f, -90.0f, 0.0f);
        }
        if (col == "diamond")
        {
            FindObjectOfType<GameManager>().DiamondScore();
            diamondInRow++;
            if (diamondInRow == 4)
            {
                FeverMode();
            }
        }
        if (col == "finish")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        if (col == "obstacles" && feverMode == false)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        if (col == "green" || col == "red" || col == "cyan" || col == "yellow" || col == "magenta" || col == "orange")
        {
            if (col == color)
            {
                FindObjectOfType<GameManager>().EnemyScore();
                diamondInRow = 0;

            }

            if (col != color && feverMode == false)
            {
                FindObjectOfType<GameManager>().GameOver();
            }
            if (col != color && feverMode == true)
            {
                FindObjectOfType<GameManager>().EnemyScore();
            }
        }


        if (col == "blue check")
        {
            body.GetComponent<Renderer>().material.color = new Color (0.2627f, 0.6666f, 0.5450f, 1);
            color = "cyan";
        }
        if (col == "red check")
        {
            body.GetComponent<Renderer>().material.color = new Color(1, 0.0862f, 0.3294f, 1);
            color = "red";
        }
        if (col == "yellow check")
        {
            body.GetComponent<Renderer>().material.color = new Color(0.9764f, 0.7803f, 0.3098f, 1);
            color = "yellow";
        }
        if (col == "magenta check")
        {
            body.GetComponent<Renderer>().material.color = new Color(0.8705f, 0.6666f, 1, 1); ;
            color = "magenta";
        }
        if (col == "orange check")
        {
            body.GetComponent<Renderer>().material.color = new Color(0.9529f, 0.4470f, 0.1725f, 1);
            color = "orange";
        }
    }
}