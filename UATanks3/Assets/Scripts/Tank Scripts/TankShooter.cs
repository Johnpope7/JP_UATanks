using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
    #region Variables
    public GameObject m_tankBulletPrefab; //stores the prefab for the tank bullet, may move to the Tank Data script
    #endregion

    #region default methods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region custom methods
    public void Shoot() 
    {
        //TODO: Cooldown Timer on Shooting
        Debug.Log("Shots Fired");
        //TODO: Instantiate a tank bullet
        //TODO: Add force to the tank bullet
    }
    #endregion
}
