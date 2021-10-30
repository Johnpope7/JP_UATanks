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

                movement = Input.GetAxis("Vertical");
                turn = Input.GetAxis("Horizontal");
                motor.Move(new Vector3(movement, 0, 0));
                motor.Turn(turn);

                if (Input.GetKey(KeyCode.Space))
                {
                    pawn.Shoot(pawn.p_shotForce);
                }

                break;

            case InputScheme.arrowKeys:

                movement = Input.GetAxis("Vertical");
                turn = Input.GetAxis("Horizontal");
                motor.Move(new Vector3(movement, 0, 0));
                motor.Turn(turn);

                if (Input.GetKey(KeyCode.RightAlt))
                {
                    pawn.Shoot(pawn.p_shotForce);
                }
                break;
        }
    }
}

