using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankMotor))]
[RequireComponent(typeof(TankShooter))]

public class PlayerController : MonoBehaviour
{
    #region Variables
    private TankData m_data; //variable for storing the required Tank Data component
    private TankMotor m_motor; //variable for storing the required Tank Motor component
    private TankShooter m_shooter; //variable for storing the required Tank Shooter component
    public enum InputScheme { WASD, arrowKeys }; //stores two input schemes, for multiplayer
    public InputScheme m_playerInputScheme = InputScheme.WASD; //sets the input scheme to WASD for now
    #endregion

    #region default methods
    // Start is called before the first frame update
   private void Start()
    {
        m_data = gameObject.GetComponent<TankData>(); //sets the proper Tank Data script for the player
       m_motor = gameObject.GetComponent<TankMotor>(); //sets the proper Tank Motor script for the player
        m_shooter = gameObject.GetComponent<TankShooter>(); //sets the proper Tank Shooter script for the player
    }

    // Update is called once per frame
    private void Update()
    {
        switch (m_playerInputScheme) //This switch statement handles movement, mainly the input schemes for WASD and the Arrow Keys
        {
            case InputScheme.WASD: //case for WASD controls
                //handles movement speed
                if (Input.GetKey(KeyCode.W))
                {
                    m_motor.Move(m_data.moveSpeed);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    m_motor.Move(-m_data.moveSpeed);
                }
                else //need to pass in a movement speed of 0 to ensure gravity is being used
                {
                    m_motor.Move(0f); 
                }
                //handles rotation
                if (Input.GetKey(KeyCode.A))
                {
                    m_motor.Rotate(-m_data.rotateSpeed);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    m_motor.Rotate(m_data.rotateSpeed);
                }
                //handles the tanks attack, shooting
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_shooter.Shoot(); ;
                }
                break;
            case InputScheme.arrowKeys: //case for Arrow Keys Controls
                //handles movement speed
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    m_motor.Move(m_data.moveSpeed);
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    m_motor.Move(m_data.moveSpeed);
                }
                else //need to pass in a movement speed of 0 to ensure gravity is being used
                {
                    m_motor.Move(0f);
                }
                //handles rotation
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    m_motor.Rotate(-m_data.rotateSpeed);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    m_motor.Rotate(m_data.rotateSpeed);
                }
                //handles the tanks attack, shooting
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_shooter.Shoot();
                }
                break;
            default:
                Debug.LogWarning("[PlayerController1] Unimplemented Input Scheme used."); //default debug output if WASD or Arrow Keys arent found
                break;

        }
    }
    #endregion

    #region custom methods

    #endregion
}
