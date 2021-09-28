using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    //motor for all pawns
    public Health health; //holds the health class for the pawn
    public TankMotor motor; //holds the movement handler, tank motor, for the pawn
    public int points; //decides how many points a pawn is worth
    protected bool isDead; //a boolean for death logic later
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }
    public void Death() //the function that handles the death of all pawns
    {
        float ch = health.GetHealth();
        if (ch <= 0) 
        {
            GameManager.instance.UpdateScore(points); //wrties the new score to the game manager
            Destroy(gameObject); //destroys pawn
            isDead = true; //sets isDead variable which will be used later
        }
    
    }
}
