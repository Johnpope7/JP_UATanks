using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
public class TankShooter : MonoBehaviour
{
    #region Variables
    private TankData m_data;
    public Transform firingZone;

    public GameObject m_tankBulletPrefab; //stores the prefab for the tank bullet, may move to the Tank Data script
    public float m_cooldownTimer = 0f;
    #endregion

    #region default methods
    // Start is called before the first frame update
    private void Start()
    {
        m_data = gameObject.GetComponent<TankData>(); //sets the proper Tank Data script for the player
    }

    // Update is called once per frame
    private void Update()
    {
        if (!CanShoot())
        {
            m_cooldownTimer -= Time.deltaTime;
        }
    }
    #endregion

    #region custom methods
    public void Shoot() 
    {
        if (CanShoot())
        {
            Debug.Log("Shots Fired");
            //TODO: Instantiate a tank bullet
            GameObject tankBullet = Instantiate(m_tankBulletPrefab, firingZone.position, firingZone.rotation);
            //TODO: Add force to the tank bullet
            m_cooldownTimer = m_data.secondsPerShot;//Resets the cooldown timer
        }

    }

    //Helper method for shot cooldown.
    public bool CanShoot() 
    {
        return (m_cooldownTimer <= 0f);
    }
    #endregion
}
