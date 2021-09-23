using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Variables
    public GameObject instigator; //stores the object that fires this bullet

    private float bulletDamage; //the damage value of the bullet



    #endregion

    #region BuiltIn Method
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player") || _other.CompareTag("Enemy"))
        {
           
        }
    }

    #endregion

    #region CustomMethods

    #region GettersAndSetters
    public float GetShellDamage //the getter for the damage
    {
        get { return bulletDamage; }
    }
    public float SetShellDamage(float dmg) //the setter of the damage
    {
        bulletDamage = dmg;
        return bulletDamage;
    }

    #endregion

    #endregion
}