using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Controller
{
    public enum InputScheme { WASD, arrowKeys };
    public InputScheme input = InputScheme.WASD;
    protected float movement;
    protected float turn;
    void Start()
    {
        pawn = GetComponent<Pawn>();
        motor = GetComponent<TankMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        //switch statement for control schemes
        switch (input)
        {
            case InputScheme.WASD:
                if (Input.GetKey(KeyCode.W))
                {
                    motor.Move();
                }
                if (Input.GetKey(KeyCode.S))
                {
                    motor.Move();
                }
                if (Input.GetKey(KeyCode.A))
                {
                    motor.Move();
                }
                if (Input.GetKey(KeyCode.D))
                {
                    motor.Move();
                }
                if (Input.GetKey(KeyCode.Space))
                {
                    pawn.Shoot(pawn.p_shotForce);
                }

                break;

            case InputScheme.arrowKeys:

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    motor.Move();
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    motor.Move();
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    motor.Move();
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    motor.Move();
                }
                if (Input.GetKey(KeyCode.RightAlt))
                {
                    pawn.Shoot(pawn.p_shotForce);
                }
                break;
        }
    }
}

