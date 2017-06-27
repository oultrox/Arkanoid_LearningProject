using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private int playerScore;
    private int playerLife;

    [SerializeField] private  Text playerScoreText;
    [SerializeField] private  Text playerLifeText;

    // ------------ Métodos API ------------------------

    // Use this for initialization
    void Start ()
    {
        InitGame();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playerLife <=0)
        {
            playerLife = 5;
            SceneManager.LoadScene(1);
        }
		
	}

    // ----- Métodos custom------
    public void SetPlayerScore(int score)
    {
        playerScore = score;
        if (playerScoreText!=null)
        {
            playerScoreText.text = "Score: \n " + score;
        }
        

    }
    public int GetPlayerScore()
    {
        return playerScore;

    }

    public void SetPlayerLife(int life)
    {
        playerLife = life;
        if (playerLifeText!=null)
        {
            playerLifeText.text = "Lifes: \n " + life;
        }
    }
    public int GetPlayerLife()
    {
        return playerLife;

    }

    private void InitGame()
    {
        playerScore = 0;
        playerLife = 5;
        SetPlayerLife(playerLife);
        SetPlayerScore(playerScore);

    }
}
