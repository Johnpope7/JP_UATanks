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
        ePawn = GetComponent<Pawn>();
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
                if (Input.GetKey(KeyCode.E))
                {
                    motor.TurretRotateRight();
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    motor.TurretRotateLeft();
                }
                if (Input.GetKey(KeyCode.Space))
                {
                    ePawn.Shoot(ePawn.p_shotForce);
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
                if (Input.GetKey(KeyCode.Keypad1))
                {
                    motor.TurretRotateRight();
                }
                if (Input.GetKey(KeyCode.RightShift))
                {
                    motor.TurretRotateLeft();
                }
                if (Input.GetKey(KeyCode.RightAlt))
                {
                    ePawn.Shoot(ePawn.p_shotForce);
                }
                break;
        }
    }
}

