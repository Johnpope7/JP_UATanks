using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{

    public static GameManager instance;
    public float score;

    // Start is called before the first frame update

    void PlayerDeath() 
    {
        
    }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
