using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int enemyScore = 0;
    public int diamondScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnemyScore()
    {
        enemyScore++;
    }
    public void DiamondScore()
    {
        diamondScore++;
        
        
    }
}
