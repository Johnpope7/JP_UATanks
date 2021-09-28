using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour 
{
    //our gamemanager instance
    public static GameManager instance;
    public int score; //the players score
    public Text scoreText;
    //and this makes it a comment sammich

    // Start is called before the first frame update

    void PlayerDeath() 
    {
        //DO NOT DESTROY THE PLAYER,
        //JUST DISABLE THEIR COLLIDERS
    }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
        //set the initial text in the score ui to say 0
        scoreText.text = "Score: 0" + score;
        //actually set score to zero afterwards cause Im super smart
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //method for updating the players points
    public void UpdateScore(int _points) 
    {
        score += _points;
        scoreText.text = "Score: " + score;
    }
}
