using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMotor : MonoBehaviour
{
    private Rigidbody tm_rb;
    private PlayerTank tdata;
    public Transform turretTf;


    public void MoveForward() 
    {
        tm_rb.MovePosition(tm_rb.position + (transform.forward * tdata.moveSpeed * Time.deltaTime) );
    }

    
    public void MoveBackward() 
    {
        tm_rb.MovePosition(tm_rb.position - (transform.forward * tdata.moveSpeed * Time.deltaTime));
    }

    public void RotateLeft() 
    {
        transform.Rotate(0, -tdata.rotateSpeed * Time.deltaTime, 0);
    }

    public void RotateRight()
    {
        transform.Rotate(0, tdata.rotateSpeed * Time.deltaTime, 0);
    }

    public void TurretRotateLeft()
    {
        turretTf.transform.Rotate(0, -tdata.turretRotateSpeed * Time.deltaTime, 0);
    }

    public void TurretRotateRight()
    {
        turretTf.transform.Rotate(0, tdata.turretRotateSpeed * Time.deltaTime, 0);
    }

    // Start is called before the first frame update
    private void Start()
    {
        tm_rb = GetComponent<Rigidbody>();
        tdata = GetComponent<PlayerTank>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
