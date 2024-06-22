using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : HealthBase
{
    // Start is called before the first frame update
    public float initHealth;
    
    
    
    void Start()
    {
        health = initHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
