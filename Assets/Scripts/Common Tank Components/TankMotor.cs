using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMotor : MonoBehaviour
{
    //components
    private CharacterController characterController;
    public Transform tf;
    public Pawn pawn;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //get components
        tf = GetComponent<Transform>();
        pawn = GetComponent<Pawn>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    //function for tank movement
    public void Move(Vector3 movement)
    {
        rb.velocity = new Vector3(movement.x * Time.fixedDeltaTime, 0, movement.z * Time.fixedDeltaTime);
    }


    //tank turning functions
    public void Turn(float speed)
    {
        //create a vector 3 set equal to y1 multiplied by speed and adjust to seconds
        Vector3 rotateVector = Vector3.up * speed * Time.deltaTime;
        //rotate our tank in local space by this value
        tf.Rotate(rotateVector, Space.Self);
    }

    //RotateTowards (Target, Speed) - rotate towards the target (if possible).
    //If we rotate, then returns true. If we can't rotate returns false.
    public bool RotateTowards(Vector3 target, float speed)
    {
        //find the vector to our target by finding the difference between the target position and our position
        Vector3 vectorToTarget = target - tf.position;
        //find the quaternion that looks down that vector
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget);
        if (targetRotation == tf.rotation)
        {
            return false;
        }
        else
        {
            tf.rotation = Quaternion.RotateTowards(tf.rotation, targetRotation, pawn.rotateSpeed * Time.deltaTime);
            return true;
        }
    }
    public void TurretRotateLeft()
    {
        pawn.turretTf.transform.Rotate(0, pawn.turretRotateSpeed * Time.deltaTime, 0);
    }

    public void TurretRotateRight()
    {
        pawn.turretTf.transform.Rotate(0, pawn.turretRotateSpeed * Time.deltaTime, 0);
    }
}


