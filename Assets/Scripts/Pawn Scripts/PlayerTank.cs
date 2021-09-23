using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : Pawn
{
    //move speed for the tank
    public float moveSpeed;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<TankMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
