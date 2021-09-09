using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMotor : MonoBehaviour
{
    #region Variables
    private float moveSpeed;
    private float rotateSpeed;
    private CharacterController m_characterController;

    #endregion

    #region default methods
    // Start is called before the first frame update
    private void Start()
    {
        m_characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region custom methods
    public void Move(float moveSpeed) 
    {
        Vector3 movementVector = transform.forward * moveSpeed;
        m_characterController.SimpleMove(movementVector);
    }

    public void Rotate(float rotateSpeed) 
    {
        Vector3 rotationVector = transform.up * rotateSpeed * Time.deltaTime;
        transform.Rotate(rotationVector);
    }

    #endregion
}
