using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : Pawn
{
    #region Variables
    //move speed for the tank
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
    public float noise = 0; //float for how much noise our pawn is making
    public float noiseRange = 10; //float for how far the noise our pawn is making travels
    public bool isMakingNoise = false; //bool for if pawn is making noise or not

    [Header("Tank Bullet Properties")]
    public GameObject bulletPrefab; //game object for the bullet instantiation 
    private Rigidbody brb; //stores the bullet rigid body
    [SerializeField]
    private Transform firingZone; //the spot from which the bullet comes from
    public float bulletLifeSpan; //decides how long the bullet has till its destroyed

    #endregion

    #region Custom Methods
    public void Shoot(float _shotforce) //firing method
    {
        if (shootCoolDown <= 0)
        {
            //create the vector 3 variable that is equal to our firing zones forward vector multiplied by shot force
            Vector3 shotDir = firingZone.forward * shotForce;
            Debug.Log("shotDir is," + shotDir);
            //spawn the bullet
            GameObject bulletInstance = Instantiate(bulletPrefab, firingZone.position, firingZone.rotation);
            Debug.Log("bullet Instantiated");
            //get the instigator
            bulletInstance.GetComponent<Bullet>().instigator = this.gameObject;
            Debug.Log("gameObject assigned");
            //get the bulletDamage variable
            bulletInstance.GetComponent<Bullet>().SetBulletDamage(tankDamage);
            Debug.Log("tankDamage set," + tankDamage);
            //get the shell rigid body to apply force
            brb = bulletInstance.GetComponent<Rigidbody>();
            Debug.Log("Rigidbody set");
            //apply the shotforce variable to the rigid body to make the bullet move
            brb.AddForce(shotDir);
            Debug.Log("Added force to the power of " + shotDir);
            //destroy the bullet after a desired time
            Destroy(bulletInstance, bulletLifeSpan);
            Debug.Log("Bullet destroyed");
            shootCoolDown = shootCoolDownTime;
        }
    }
    #endregion

    #region BuiltIn Methods
    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<TankMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        //subtract the time from the shot cool down clamped between 0 and its cool down time
        shootCoolDown = Mathf.Clamp(shootCoolDown - Time.deltaTime, 0, shootCoolDownTime);
    }

    //function for getting the cooldown because the method I used in my declarations wasn't working for cool down
    public float GetCoolDown() 
    {
        return shootCoolDown;
    }
    #endregion
}
