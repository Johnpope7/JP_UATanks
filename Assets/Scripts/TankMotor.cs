using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMotor : MonoBehaviour
{
    private Rigidbody tm_rb;
    private PlayerTank tdata;


    public void MoveForward() 
    {
        tm_rb.MovePosition(tm_rb.position + (transform.forward * tdata.moveSpeed * Time.deltaTime) );
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
