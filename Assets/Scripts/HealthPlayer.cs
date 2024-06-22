using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : HealthBase
{

    public float initHealth = 5;
    
    
    // Start is called before the first frame update
    void Start()
    {
        health = initHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            initHealth -= 1;
        }
    }
}
