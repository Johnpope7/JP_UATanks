using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankMotor))]
[RequireComponent(typeof(TankShooter))]

public class PlayerController : MonoBehaviour
{
    #region Variables
    private TankData m_data;
    private TankMotor m_motor;
    private TankShooter m_shooter;
    public enum InputScheme { WASD, arrowKeys };
    public InputScheme m_playerInputScheme = InputScheme.WASD;
    #endregion

    #region default methods
    // Start is called before the first frame update
   private void Start()
    {
        m_data = gameObject.GetComponent<TankData>();
       m_motor = gameObject.GetComponent<TankMotor>();
        m_shooter = gameObject.GetComponent<TankShooter>();
    }

    // Update is called once per frame
    private void Update()
    {
        switch (m_playerInputScheme)
        {
            case InputScheme.WASD:
                if (Input.GetKey(KeyCode.W))
                {
                    m_motor.Move(m_data.moveSpeed);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    m_motor.Move(-m_data.moveSpeed);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    m_motor.Rotate(-m_data.rotateSpeed);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    m_motor.Rotate(m_data.rotateSpeed);
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_shooter.Shoot(); ;
                }
                break;
            case InputScheme.arrowKeys:
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    m_motor.Move(m_data.moveSpeed);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    m_motor.Move(m_data.moveSpeed);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    m_motor.Rotate(-m_data.rotateSpeed);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    m_motor.Rotate(m_data.rotateSpeed);
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_shooter.Shoot(); ;
                }
                break;
            default:
                Debug.LogWarning("[PlayerController1] Unimplemented Input Scheme used.");
                break;

        }
    }
    #endregion

    #region custom methods

    #endregion
}
