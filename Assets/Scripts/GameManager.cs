using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemyScore = 0;
    public int diamondScore = 0;
    public Text enemyScoreText;
    public Text diamondScoreText;
    public GameObject player;
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
        enemyScoreText.text = enemyScore.ToString();
    }
    public void DiamondScore()
    {
        diamondScore++;
        diamondScoreText.text = diamondScore.ToString();
        
    }
    public void DiamondZero()
    {
        diamondScore = 0;
        diamondScoreText.text = diamondScore.ToString();
    }
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
