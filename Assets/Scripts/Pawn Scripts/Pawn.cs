using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    //motor for all pawns
    public Health health;
    public TankMotor motor;
    public int points;
    protected bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }
    public void Death() 
    {
        float ch = health.GetHealth();
        if (ch <= 0) 
        {
            GameManager.instance.UpdateScore(points);
            Destroy(gameObject);
            isDead = true;
        }
    
    }
}
