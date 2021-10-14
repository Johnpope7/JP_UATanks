using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyTank : Pawn
{
    [Header("Movement Properties")]
    public float moveSpeed; //movement speed of the tank
    public float rotateSpeed; //turn speed of the tank
    public float turretRotateSpeed; //determines the rotation speed of the turret

    [Header("Tank Stats")]
    private float shotForce = 20000f; //speed of the bullet shot
    public float p_shotForce  //gets the speed of the bullet
    {
        get { return shotForce; }
    }
    [SerializeField]
    private float tankDamage = 25f; //damage the player tank does
    [SerializeField]
    private float shootCoolDown; //the cooldown time between shoots, dont change this in the inspector
    [SerializeField]
    private float shootCoolDownTime = 2f; //the time our cool down takes to refresh, adjust this to shoot faster or slower

    [Header("AI Settings")]
    public float withinWaypointRange; //close enough distance to waypoint
    public float viewRadius = 10; //for radius of player detection
    public float fieldOfView = 180f; //for Ai field of view
    public float hearingDistance = 10; //distance ai can hear
}
