using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyTank))]
[RequireComponent(typeof(TankMotor))]
public class AIController : Controller
{
    #region Variables
    [Header("AI Controller Components")]
    public GameObject target; //stores the AI's target
    public Transform targetTf; //stores the transform of the AI's target
    public EnemyTank pawn; //stores the pawn of the EnemyTank
    protected Transform tf; //stores the transform of the AI pawn
    public LayerMask playerLayer; //allows me to access the player layer;

    [Header("Navigation Variables")]
    public int avoidanceStage = 0;
    public float avoidanceTime = 2.0f;
    private float exitTime = 0.5f; //variable that stores Move exit times
    public float stateEnterTime; //variable to store the time a state was entered
    public float stateExitTime = 30.0f; //float that determines state exiting time
    public float restingHealthRate; //sets the heal rate in hp per second
    public float fleeDistance = 1.0f;
    public int currentWaypoint = 0; //stores ai's current value in waypoint index
    public float withinWaypointRange = 1.0f; //value for if our ai is close enough to its waypoint
    public float stopDistance; //to stop AI before they enter the players space

    #endregion

    #region Builtin functions
    void Awake()
    {
        tf = GetComponent<Transform>(); //sets the transform of the AI pawn
        pawn = GetComponent<EnemyTank>(); //gets the pawn of the AI pawn
        motor = GetComponent<TankMotor>(); //gets the TankMotor and sets it to motor
    }

    void Start()
    {

    }


    void Update()
    {
        
    }
    #endregion

    #region Custom Functions

    #region Senses
    public bool Move(float speed)
    {

        if (Physics.Raycast(tf.position, tf.forward, out RaycastHit hit, speed)) //raycasts off the transform forward and checks to see if we hit the player
        {
            
            if (!hit.collider.CompareTag("Player")) //if our raycast doesnt hit a player
            {
                return false; //move returns false
            }
        }
        return true; //if it is a player tahn it returns true
    }

    public bool Hear(GameObject _player)
    {
        //creates local variables for everything we need to hear
        float _playerNoise = _player.GetComponent<PlayerTank>().noise; //stores the noise level of the player
        float _playerNoiseRange = _player.GetComponent<PlayerTank>().noiseRange; //stores the hearing distance of the noise
        float hDistance = pawn.hearingDistance; //makes a local variable for hearing distance
        if (_playerNoise > 0)
        {
            // If our distance is greater or equal to the distance we can hear plus the distance the pawn's noise travels
            if (Vector3.Distance(target.transform.position, tf.position) <= hDistance + _playerNoiseRange)
            {
                return true; //returns Hear as true
            }
        }
        return false; //if anything else than it returns Hear as false
    }

    public bool See(GameObject player)
    {

        Vector3 agentToPlayerVector = player.transform.position - pawn.transform.position; //stores the distance between the enemy and the target player

        float angleToPlayer = Vector3.Angle(agentToPlayerVector, pawn.transform.right);//finds the angle from our enemies view by using the distance between the player and the enemies transform 

        
        if (angleToPlayer < pawn.fieldOfView) //does this if our angle to our player is lest that our field of view
        {
            if (Vector3.Distance(pawn.transform.position, player.transform.position) < pawn.viewRadius / 2)
            {
                //checks to see if we hit thje player target
                if (Physics.Raycast(pawn.transform.position, agentToPlayerVector, out RaycastHit hit, pawn.viewRadius, playerLayer))
                {
                    // If our raycast hits our player target
                    if (hit.collider.gameObject == player)
                    {
                        // return true 
                        return true;
                    }
                    else
                    {
                        return false; //if its not our target then return false
                    }
                }
            }
        }
        return false;
    }
    #endregion

    #endregion
}

