using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Controller
{
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        pawn = GetComponent<Pawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            pawn.motor.MoveForward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            pawn.motor.MoveBackward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            pawn.motor.RotateLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            pawn.motor.RotateRight();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            pawn.motor.TurretRotateLeft();
        }
        if (Input.GetKey(KeyCode.E))
        {
            pawn.motor.TurretRotateRight();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ptank.Shoot(ptank.p_shotForce);
        }
    }
}
